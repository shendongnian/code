    async void Main()
    {
        await NotWorking();
    }
    
    public async Task NotWorking()
    {
        using (var evil = new EvilStruct())
        {
            await Task.Delay(100);
            evil.Mutate();
            Debug.WriteLine(evil.Value);
        }
    }
    
    public struct EvilStruct : IDisposable
    {
        public int Value;
        public void Mutate()
        {
            Value++;
        }
    
        public void Dispose()
        {
        }
    }

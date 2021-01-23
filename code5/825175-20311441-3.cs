    class Program
        {
            static void Main(string[] args)
            {
                DoWork();
            }
    
            static async void DoWork()
            {
                await YourVoidMethod();
            }
    
            static Task YourVoidMethod()
            {
                Task task = Task.Run(() =>
                    {
                        // Your payload code
                    }
                );
    
                return task; 
            }
        }

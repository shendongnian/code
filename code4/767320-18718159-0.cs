    public class Data
    {
        public int Op {get; set;}
        public int Result {get; set;}
    }
    
    public async void Method1()
    {
        TaskData data = await GetDataTaskAsync();
        // use data.Op and data.Result from here on
    }
    
    public async Task<Data> GetDataTaskAsync()
    {
        var returnValue = new Data();
        // Fill up returnValue
        return returnValue;
    }

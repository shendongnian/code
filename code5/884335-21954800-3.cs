    public async Task<string> GetParsedData(string code){
        Console.WriteLine("Starting parser");
        var taskResult = await Task.Run(() =>
        {
            var result = "";
            foreach(var x in code.Split('\n'))
            {
                result += Encode(x);
            }
 
            return result;
        });
        return taskResult;
    }

    private Task<bool> SearchFilesAsync(string path)
    {
        return Task<bool>.Factory.StartNew(() =>
    	{
    	     return Directory.GetFiles(path, "*.txt", SearchOption.AllDirectories).Any();
    	});
    	
    }
    private void CheckTxtFile()
    {
        string myPath = @"SearchPathHere";
        SearchFilesAsync(myPath).ContinueWith(myTask =>
        {
             Console.WriteLine("Text file found : {0}", myTask.Result.ToString());
        });
    }

    private async void button1_Click(object sender, EventArgs e)// <--Note the async modifier
    {
         var tasks = Processes.Select(ProcessObject).ToList();
         await Task.WhenAll(tasks);
    }

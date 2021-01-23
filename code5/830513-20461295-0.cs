    private async void btnStart_Click(object sender, RoutedEventArgs e)
    {
      var progress = new Progress<string>(value => { txtResult1.Text = value; });
      await Task.WhenAll(ReadCharacterAsync("C:\\File 1.txt", progress),
          ReadCharacterAsync("C:\\File 2.txt", progress),
          ReadCharacterAsync("C:\\File 3.txt", progress));
      MessageBox.Show("Done");
    }
    private async Task ReadCharacterAsync(string inputFile, IProgress<string> progress)
    {
        string result; string TID;
        using (var inFile = new FileStream(inputFile, FileMode.Open, FileAccess.Read, FileShare.None, 8192, useAsync: true))
        using (var outFile = new FileStream(string.Format("{0}--Out.txt", inputFile.Replace(".txt","")), FileMode.Create, FileAccess.ReadWrite, FileShare.None, 8192, useAsync: true))
        using (StreamReader sr =new StreamReader(inFile))
        using (StreamWriter sw = new StreamWriter(outFile))
        {
            var sb = new StringBuilder();
            TID = "Thread ID: "+ Thread.CurrentThread.ManagedThreadId.ToString();
            sb.AppendLine(TID);
            sb.AppendLine("T Start : " + DateTime.Now.ToLongTimeString() + "." + 
                    DateTime.Now.Millisecond).ToString();
            while (!sr.EndOfStream)
            {
                result = await sr.ReadLineAsync();
                await sw.WriteLineAsync(result);
            };
            progress.Report(
            sb.AppendLine("T Stop : "+DateTime.Now.ToLongTimeString() + "." + 
                    DateTime.Now.Millisecond).ToString());
        } 
    }

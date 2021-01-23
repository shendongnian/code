    BackgroundWorker bw = sender as BackgroundWorker;
    StreamReader sr = new StreamReader("C:\\File 1.txt");
    StreamWriter sw = new StreamWriter("C:\\Out-File 1.txt");
    
    var fi = new FileInfo("C:\\File 1.txt");
    long total = (char)fi.Length;
    int  i = 0;
    string result;
    long updateIncrement = total / 100;
    long nextUpdate = 0;
    while (!sr.EndOfStream)
    {
        if (!bw.CancellationPending)
        {
            result = sr.ReadLine();
            sw.WriteLine(result);
            i = i + (char)result.Length;
            if ( i > nextUpdate )
            {
                nextUpdate += updateIncrement;
                bw.ReportProgress((int)((decimal)i / (decimal)total * (decimal)100));
            }
        }
        else
        {
            e.Cancel = true; 
            break;
        }
    } 
    sw.Close(); 
    sr.Close();

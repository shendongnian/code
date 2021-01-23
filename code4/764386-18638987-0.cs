    string path = "";
    Stopwatch stopWatch = new Stopwatch();
    stopWatch.Start();
    var excel = new Microsoft.Office.Interop.Excel.Application();
    excel.Workbooks.Open(path, Type.Missing, false, Type.Missing, Type.Missing,
                    Type.Missing, false, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing);
    stopWatch.Stop();
    // Get the elapsed time as a TimeSpan value.
    TimeSpan ts = stopWatch.Elapsed;
    // Format and display the TimeSpan value.
    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
    Console.WriteLine("RunTime " + elapsedTime);
    Console.ReadKey();

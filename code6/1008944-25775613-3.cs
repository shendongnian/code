    string sox = @"C:\Program Files (x86)\sox-14-4-1\sox.exe";
    string inputFile = @"D:\Brothers Vibe - Rainforest.mp3";
    string outputDirectory = @"D:\splittest";
    string outputPrefix = "split";
    int[] segments = { 10, 15, 30 };
    IEnumerable<string> enumerable = segments.Select(s => "trim 0 " + s.ToString(CultureInfo.InvariantCulture));
    string @join = string.Join(" : newfile : ", enumerable);
    string cmdline = string.Format("\"{0}\" \"{1}%1n.wav" + "\" {2}", inputFile,
        Path.Combine(outputDirectory, outputPrefix), @join);
    var processStartInfo = new ProcessStartInfo(sox, cmdline);
    Process start = System.Diagnostics.Process.Start(processStartInfo);

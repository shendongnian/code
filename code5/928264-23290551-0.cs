    Process process = new Process();
    process.StartInfo.Arguments = @"status PATH /recursive";
    process.StartInfo.FileName = "tf.exe";
    process.StartInfo.CreateNoWindow = false;
    process.StartInfo.UseShellExecute = false;
    process.StartInfo.RedirectStandardError = true;
    process.StartInfo.RedirectStandardOutput = true;
    process.Start();
    
    var st = process.StandardOutput.ReadToEnd();
    var err = process.StandardError.ReadToEnd();

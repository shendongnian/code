    ProcessStartInfo start = new ProcessStartInfo();
    start.FileName = @"cmd.exe"; // Specify exe name.
    start.Arguments = "python --version";
    start.UseShellExecute = false;
    start.RedirectStandardError = true;
    start.CreateNoWindow = true;
    
    using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardError)
                {
                    string result = reader.ReadToEnd();
                    MessageBox.Show(result);
                }
            }

    using (var process = Process.Start(
        new ProcessStartInfo
        {
            FileName = fileName,
            Arguments = args,
            WindowStyle = ProcessWindowStyle.Hidden,
            CreateNoWindow = true,
            RedirectStandardError = true,
            UseShellExecute = false,
        }))
    {
        process.WaitForExit();
         if (process.ExitCode != 0)
         {
            var errorMessage = process.StandardError.ReadToEnd();
            Assert.Fail(errorMessage);
         }
    }

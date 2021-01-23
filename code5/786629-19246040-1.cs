    using (exeProcess = Process.Start(startInfo))
    {
        exeProcess.OutputDataReceived +=
            (sender, args) =>
                {
                    scanning.Text = args.Data;
                    scanning.Refresh();
                    Console.Write(args.Data);
                };
        exeProcess.BeginOutputReadLine();
        // do whatever you want here
        exeProcess.WaitForExit();
    }

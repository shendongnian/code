    ...
    process = Process.Start(processInfo);
    process.ErrorDataReceived += (sender, eargs) =>
    {
        // do something
    };
    process.OutputDataReceived += (sender, eargs) =>
    {
        // do something
    };
    if (timeout > 0)
    {
        // if it is a slow process, read async
        if (!process.WaitForExit(200))
        {
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            if (!process.WaitForExit(timeout))
            {
                // show error
                return;
            }
           
        } else
        {
            // if it is fast process, need to use "ReadToEnd", because async read will not 
            // caputure output
            var text = process.StandardOutput.ReadToEnd();
            // do something with text
            
        }
        exitCode = process.ExitCode;
    }

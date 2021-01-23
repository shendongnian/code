    StringBuilder outStr = new StringBuilder("");
    StringBuilder errStr = new StringBuilder("");
    process.Start();
    process.OutputDataReceived += (sendingProcess, outLine) =>
    {
        outStr.AppendLine(outLine.Data);
        Console.Out.WriteLine(outLine.Data); // echo the output
    };
    
    process.ErrorDataReceived += (sendingProcess, errorLine) =>
    {
        errStr.AppendLine(errorLine.Data);
        Console.Error.WriteLine(errorLine.Data); // echo the error
    };
    
    process.BeginOutputReadLine();
    process.BeginErrorReadLine();

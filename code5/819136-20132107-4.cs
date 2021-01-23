        var flagPrintToPrinter = String.Format("-print-to \"{0}\"", printerName);
        var flagSilentAndSuppressErrors = "-silent";
        var args = String.Format("{0} {1} \"{2}\"", flagPrintToPrinter, flagSilentAndSuppressErrors, printFileName);
        var currentDirectory = Environment.CurrentDirectory;
        var process = new Process
        {
          StartInfo = {FileName = String.Format(@"{0}\ThirdPartyAssemblies\SumatraPDF.exe", currentDirectory), Arguments = args}
        };
        process.Start();
        process.WaitForExit();
        var exitCode = process.ExitCode;
        process.Close();

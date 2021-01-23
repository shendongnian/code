    string CompileC (string code)
    {
        string path = @"C:\sample.c";
        string results = "";
        try
        {
            if (File.Exists(path))
                File.Delete(path);
            using (FileStream fs = File.Create(path))
            {
                byte[] codeText = new UTF8Encoding(true).GetBytes(code);
                fs.Write(codeText, 0, codeText.Length);
            }
            Process process = new Process();
            process.StartInfo.FileName = @"C:\Windows\system32\cmd.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            using (StreamWriter sw = process.StandardInput)
            {
                if (sw.BaseStream.CanWrite)
                {
                    //This batch starts up the Visual Studio Command Prompt.
                    sw.WriteLine(@"C:\Startup.bat");
                    //This batch does the compilation, once the Command Prompt
                    //is running, using the 'cl' command.
                    sw.WriteLine(@"C:\Compile.bat");
                }
            }
            using (StreamReader sr = process.StandardOutput)
            {
                if (sr.BaseStream.CanRead)
                    results = sr.ReadToEnd();
            }
        }
        catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        return results;
    }

    public void compress(string inputfilename, string outputfilename, string workingfolder)
    {
        string the_rar;
        RegistryKey the_Reg;
        object the_Obj;
        string the_Info;
        ProcessStartInfo the_StartInfo;
        Process the_Process;
        try
        {
            the_Reg = Registry.ClassesRoot.OpenSubKey(@"WinRAR\shell\open\command");//for winrar path
            the_Obj = the_Reg.GetValue("");
            the_rar = the_Obj.ToString();
            the_Reg.Close();
            the_rar = the_rar.Substring(1, the_rar.Length - 7);
            the_Info = " a " + " " + outputfilename + " " + " " + inputfilename;//i dare say for parameter
            the_StartInfo = new ProcessStartInfo();
    
            the_StartInfo.FileName = the_rar;
            the_StartInfo.Arguments = the_Info;
            the_StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            the_StartInfo.UseShellExecute = false;
            the_StartInfo.WorkingDirectory = workingfolder;
            the_Process = new Process();
            the_Process.StartInfo = the_StartInfo;
            the_Process.Start();//starting compress Process
            the_Process.Close();
            the_Process.Dispose();
        }
        catch (Exception ex)
        {
          System.Diagnostics.Debug.WriteLine(ex.Message);
        }
    }

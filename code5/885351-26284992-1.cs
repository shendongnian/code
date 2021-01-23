    internal static void InstalarFuente(string NombreFnt,string RutaFnt)
    {
        string CMD = string.Format("copy /Y \"{0}\" \"%WINDIR%\\Fonts\" ", RutaFnt);
        EjecutarCMD(CMD);
        System.IO.FileInfo FInfo = new System.IO.FileInfo(RutaFnt);
        CMD = string.Format("reg add \"HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Fonts\" /v \"{0}\" /t REG_SZ /d {1} /f", NombreFnt, FInfo.Name);
        EjecutarCMD(CMD);
    }
    public static void EjecutarCMD(string Comando)
    {
        System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo("cmd.exe");
        Info.Arguments = string.Format("/c {0}", Comando);
        Info.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
        System.Diagnostics.Process.Start(Info);
    }
.....

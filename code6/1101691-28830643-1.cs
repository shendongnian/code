     System.Diagnostics.ProcessStartInfo netshprocess = new System.Diagnostics.ProcessStartInfo();
     netshprocess.FileName = "netsh.exe";
     string temp = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
     string user = "";
     for (int i = 0; i < temp.Length; i++)
     {
         user += temp[i];
         if (temp[i] == '\\')
         {
             user = "";
         }
     }
     netshprocess.Verb = "runas";
     netshprocess.Arguments = "";
     netshprocess.Arguments = "http add urlacl url=http://+:7015/MeasurementTransferWCF user=" + user;
     netshprocess.UseShellExecute = true;
     try
     {
         System.Diagnostics.Process.Start(netshprocess).WaitForExit();
     }
     catch (Exception)
     { }

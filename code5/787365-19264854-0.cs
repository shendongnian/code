    public class NetworkConnection : IDisposable
     {
         string _networkName;
         uint dwFlags;
         public NetworkConnection(string networkName, NetworkCredential credentials)
         {
             _networkName = networkName;
    
             var netResource = new NetResource()
             {
                 Scope = ResourceScope.GlobalNetwork,
                 ResourceType = ResourceType.Disk,
                 DisplayType = ResourceDisplaytype.Share,
                 RemoteName = networkName
             };
    
             var userName = string.IsNullOrEmpty(credentials.Domain)
                 ? credentials.UserName
                 : string.Format(@"{0}\{1}", credentials.Domain, credentials.UserName);
    
             var result = WNetAddConnection2(netResource,"","",0x00000008 | 0x00000010);
    
             if (result != 0)
             {
                 string strErrMsg = "";
                 if (result == 67)
                 {
                     strErrMsg = "The network name cannot be found.";
                 }
                 if (result == 86)
                 {
                     strErrMsg = "Invalid UserName or Password for ProBiz server";
                 }
                 else if (result == 1219)
                 {
                     strErrMsg = "Multiple connections to a server or shared resource by the same user, using more than one user name, are not allowed.Close application to Disconnect all previous connections to the server or shared resource and try again.";
                 }
    
                 throw new Win32Exception(result, "Error connecting to "+networkName+" remote share.Error Code:"+result.ToString()+"."+strErrMsg);
             }
             else
             {
                 MessageBox.Show("Test connection is successful for "+ networkName);
             }
         }
    
         ~NetworkConnection()
         {
             Dispose(false);
         }
    
         public void Dispose()
         {
             Dispose(true);
             GC.SuppressFinalize(this);
         }
    
         protected virtual void Dispose(bool disposing)
         {
             WNetCancelConnection2(_networkName,  1, true  );
             var command = "NET USE  /delete *";
             ExecuteCommand(command, 5000);
    
         }
         public static int ExecuteCommand(string command, int timeout)
         {
             var processInfo = new ProcessStartInfo("cmd.exe", "/C " + command)
             {
                 CreateNoWindow = true,
                 UseShellExecute = false,
                 WorkingDirectory = "C:\\",
             };
    
             var process = Process.Start(processInfo);
             process.WaitForExit(timeout);
             var exitCode = process.ExitCode;
             process.Close();
             return exitCode;
         } 
    
         [DllImport("mpr.dll")]
         private static extern int WNetAddConnection2(NetResource netResource,
             string password, string username, int flags);
    
         [DllImport("mpr.dll")]
         private static extern int WNetCancelConnection2(string name, int flags,
             bool force);
     }
    
     [StructLayout(LayoutKind.Sequential)]
     public class NetResource
     {
         public ResourceScope Scope;
         public ResourceType ResourceType;
         public ResourceDisplaytype DisplayType;
         public int Usage;
         public string LocalName;
         public string RemoteName;
         public string Comment;
         public string Provider;
     }
    
     public enum ResourceScope : int
     {
         Connected = 1,
         GlobalNetwork,
         Remembered,
         Recent,
         Context
     };
    
     public enum ResourceType : int
     {
         Any = 0,
         Disk = 1,
         Print = 2,
         Reserved = 8,
     }
    
     public enum ResourceDisplaytype : int
     {
         Generic = 0x0,
         Domain = 0x01,
         Server = 0x02,
         Share = 0x03,
         File = 0x04,
         Group = 0x05,
         Network = 0x06,
         Root = 0x07,
         Shareadmin = 0x08,
         Directory = 0x09,
         Tree = 0x0a,
         Ndscontainer = 0x0b
     }

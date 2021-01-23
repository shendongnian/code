      public static void SetHostname(string hostname)
      {
         if (!SetComputerName(hostname)) {
             throw new System.ComponentModel.Win32Exception();
         }
      }
      [DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
      private static extern int SetComputerName(string hostname);
 

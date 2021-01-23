        static void Main(string[] args)
        {
            System.Diagnostics.Process p1 = System.Diagnostics.Process.Start(@"C:\\Windows\\ehome\\ehshell.exe");
            System.Diagnostics.Process p2 = System.Diagnostics.Process.Start(@"E:\\Xpadder\\WMC.xpaddercontroller");
            p1.Exited += (s,e) => {
               if(!p2.HasExited) p2.Kill();
            };
            
        }

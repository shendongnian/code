    using System.Management.Automation;
    
    namespace IsoMountTest
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                var isoPath = @"C:\Foo\bar.iso";
                using (var ps = PowerShell.Create())
                {
                    ps.AddCommand("Mount-DiskImage").AddParameter("ImagePath", isoPath).Invoke();
                }
            }
        }
    }

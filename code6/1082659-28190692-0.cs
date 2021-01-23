        private string RunDxDiag() {
            var psi = new ProcessStartInfo();
            if (IntPtr.Size == 4 && Environment.Is64BitOperatingSystem) {
                // Need to run the 64-bit version
                psi.FileName = System.IO.Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Windows),
                    "sysnative\\dxdiag.exe");
            }
            else {
                // Okay with the native version
                psi.FileName = System.IO.Path.Combine(
                    Environment.SystemDirectory, 
                    "dxdiag.exe");
            }
            string path = System.IO.Path.GetTempFileName();
            try {
                psi.Arguments = "/x " + path;
                using (var prc = Process.Start(psi)) {
                    prc.WaitForExit();
                    if (prc.ExitCode != 0) {
                        throw new Exception("DXDIAG failed with exit code " + prc.ExitCode.ToString());
                    }
                }
                return System.IO.File.ReadAllText(path);
            }
            finally {
                System.IO.File.Delete(path);
            }
        }

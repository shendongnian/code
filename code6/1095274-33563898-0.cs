    public class MacClipboard
    {
        /// <summary>
        /// Copy on MAC OS X using pbcopy commandline
        /// </summary>
        /// <param name="textToCopy"></param>
        public static void Copy(string textToCopy)
        {
            try
            {
                using (var p = new Process())
                {
                    p.StartInfo = new ProcessStartInfo("pbcopy", "-pboard general -Prefer txt");
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardOutput = false;
                    p.StartInfo.RedirectStandardInput = true;
                    p.Start();
                    p.StandardInput.Write(textToCopy);
                    p.StandardInput.Close();
                    p.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Paste on MAC OS X using pbpaste commandline
        /// </summary>
        /// <returns></returns>
        public static string Paste()
        {
            try
            {
                string pasteText;
                using (var p = new Process())
                {
                    p.StartInfo = new ProcessStartInfo("pbpaste", "-pboard general");
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.Start();
                    pasteText = p.StandardOutput.ReadToEnd();
                    p.WaitForExit();
                }
                return pasteText;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                return null;
            }
        }
    }

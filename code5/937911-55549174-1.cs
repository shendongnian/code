    if (imageinfo.Checked == true)
            {
                progress = progress + interval;
                string commandlineargs = "-f " + imagefile + " imageinfo" + " --output-file=" + output + @"\imageinfo.txt";
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = vollocation;
                startInfo.Arguments = commandlineargs;
                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();
                process.Close();
               
            }

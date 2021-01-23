        static List<string> GetARP()
        {
            List<string> _ret = new List<string>();
            Process netUtility = new Process();
            netUtility.StartInfo.FileName = "arp.exe";
            netUtility.StartInfo.CreateNoWindow = true;
            netUtility.StartInfo.Arguments = "-a";
            netUtility.StartInfo.RedirectStandardOutput = true;
            netUtility.StartInfo.UseShellExecute = false;
            netUtility.StartInfo.RedirectStandardError = true;
            netUtility.Start();
            StreamReader streamReader = new StreamReader(netUtility.StandardOutput.BaseStream, netUtility.StandardOutput.CurrentEncoding);
            string line = "";
            while ((line = streamReader.ReadLine()) != null)
            {
                if (line.StartsWith("  "))
                {
                    var Itms = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (Itms.Length == 3)
                        _ret.Add(Itms[0]);
                }
            }
            streamReader.Close();
            return _ret;
        }

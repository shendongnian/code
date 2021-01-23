        private Process _proCheckWLANInterface;
        private bool CheckWirelessAdapter()
        {
            bool flag = false;
            InitProcess(out _proCheckWLANInterface,"iwconfig","");
            string strResults = executeCmd(_proCheckWLANInterface);
            var datas = strResults.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in datas)
            {
                if (item.Contains("IEEE 802.11"))
                {
                    flag= true;
                    break;
                }
                else
                {
                    logger.Warn("Does not attached Wi-Fi Radio");
                }
            }
            return flag;
           
        }
        private void InitProcess(out Process pro,string cmd, string args)
        {
            pro = new Process();
            pro.StartInfo = new ProcessStartInfo();
            pro.StartInfo.FileName = cmd;
            pro.StartInfo.Arguments = args;
            pro.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            pro.StartInfo.RedirectStandardOutput = true;
            pro.StartInfo.UseShellExecute = false;
            pro.StartInfo.CreateNoWindow = true;
        }
        private string executeCmd(Process pro)
        {
            try
            {
                pro.Start();
                pro.WaitForExit();
                //logger.Trace(pro.StandardOutput.ReadToEnd());
                return pro.StandardOutput.ReadToEnd();
            }
            catch (Exception ex)
            {
                logger.Debug("Exception in executeCmd method:", ex);
            }
            finally
            {
                pro.Close();
                pro.Dispose();
                pro = null;
            }
            return string.Empty;
        }

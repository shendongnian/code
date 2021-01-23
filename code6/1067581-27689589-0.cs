     public string SetFolderQuota(Quota quota)
            {
    
                string FileLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows),@"sysnative\dirquota.exe");
    
                Process QuotaProcess = new Process();
    
                QuotaProcess.StartInfo.RedirectStandardOutput = false;
                QuotaProcess.StartInfo.FileName = FileLocation;
                QuotaProcess.StartInfo.UseShellExecute = true;
                QuotaProcess.StartInfo.Arguments = " Quota Add /PATH:" + '"' + quota.FolderLocation + '"' + " /Limit:" + quota.SizeInMB + "mb" + " /remote:" + quota.FileServerName;
    
                try
                {                
                    QuotaProcess.Start();
                }
                catch(Exception Ex)
                {
                    return Ex.Message + Environment.NewLine + "FileLocation: " + FileLocation;
                }
    
                return "Correctly Executed: " + QuotaProcess.StartInfo.FileName + QuotaProcess.StartInfo.Arguments;
            }

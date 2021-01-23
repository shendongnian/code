    private void OnChanged(object source, FileSystemEventArgs e)
        {
            string[] temp = new string[3];
            string[] tempNow = new string[3];
            string[] tempSeconds = new string[2];
            string[] tempNowSeconds = new string[2];
            int temp1 = 0;
            int temp2 = 0;
            if(string.IsNullOrEmpty(changeName))
            {
                changeName = e.Name;
            }
            if (string.IsNullOrEmpty(changeTime))
            {
                changeTime = DateTime.Now.ToString();
                temp = this.changeTime.Split(':');
                tempNow = DateTime.Now.ToString().Split(':');
                tempSeconds = temp[2].Split(' ');
                tempNowSeconds = temp[2].Split(' ');
                temp1 = Convert.ToInt16(tempSeconds[0]);
                temp2 = Convert.ToInt16(tempNowSeconds[0]);
                // Decrypt the file.
                DecryptFile(keyPath + "\\id_rsa_Encrypted", keyPath + "\\id_rsa", sSecretKey);
                // Remove the Key from memory. 
                PKey = new PrivateKeyFile(keyPath + "\\id_rsa");
                keyResult.Text = "RSA keys Were Generated at:" + keyPath;
                ScpClient client = new ScpClient("remnux", "adi", PKey);
                string[] tempPath = e.FullPath.Split('\\');
                string fullPathNew = string.Empty;
                for (int i = 0; i < tempPath.Length - 1; i++)
                {
                    fullPathNew += tempPath[i];
                }
                if (Directory.Exists(fullPathNew))
                {
                    sshConnect(client);
                    File_Upload(e.FullPath, client);
                }
                else
                {
                    try
                    {
                        sshConnect(client);
                        System.IO.Directory.CreateDirectory(fullPathNew);
                        File_Upload(e.FullPath, client);
                    }
                    catch (Exception ex)
                    {
                        File.AppendAllText(logPath + "\\SSHErrorLog.log", "[]*******" + DateTime.Now + " Error in OnChanged function: " + ex.Message.ToString() + Environment.NewLine);
                    }
                }
            }
            if (!this.changeTime.Equals(DateTime.Now.ToString()))
            {
                temp = this.changeTime.Split(':');
                tempNow = DateTime.Now.ToString().Split(':');
                tempSeconds = temp[2].Split(' ');
                tempNowSeconds = temp[2].Split(' ');
                temp1 = Convert.ToInt16(tempSeconds[0]);
                temp2 = Convert.ToInt16(tempNowSeconds[0]);
                if (temp[2] != tempNow[2])
                {
                    if ((temp1 < temp2 + 10 || temp1 > temp2 +40) && e.Name != changeName)
                    {
                        // Decrypt the file.
                        DecryptFile(keyPath + "\\id_rsa_Encrypted", keyPath + "\\id_rsa", sSecretKey);
                        // Remove the Key from memory. 
                        PKey = new PrivateKeyFile(keyPath + "\\id_rsa");
                        keyResult.Text = "RSA keys Were Generated at:" + keyPath;
                        ScpClient client = new ScpClient("remnux", "adi", PKey);
                        string[] tempPath = e.FullPath.Split('\\');
                        string fullPathNew = string.Empty;
                        for (int i = 0; i < tempPath.Length - 1; i++)
                        {
                            fullPathNew += tempPath[i];
                        }
                        if (Directory.Exists(fullPathNew))
                        {
                            sshConnect(client);
                            File_Upload(e.FullPath, client);
                        }
                        else
                        {
                            try
                            {
                                sshConnect(client);
                                System.IO.Directory.CreateDirectory(fullPathNew);
                                File_Upload(e.FullPath, client);
                            }
                            catch (Exception ex)
                            {
                                File.AppendAllText(logPath + "\\SSHErrorLog.log", "[]*******" + DateTime.Now + " Error in OnChanged function(second if): " + ex.Message.ToString() + Environment.NewLine);
                            }
                        }
                    }
                }
            }
        }

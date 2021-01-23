    public List<string> GetARPResult()
            {
                string localIPAddress = Dns.GetHostAddresses(Environment.MachineName)[1].ToString();
                Process p = null;
                string output = string.Empty;
                List<string> listIP = new List<string>();
    
                try
                {
                    p = Process.Start(new ProcessStartInfo("arp", "-a")
                    {
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        RedirectStandardOutput = true
                    });
    
                    output = p.StandardOutput.ReadToEnd();
    
                    List<string> listArp = output.Split(' ').ToList();
    
                    for (int i = 0; i < listArp.Count; i++)
                    {
                       if (listArp[i].StartsWith(localIPAddress.Remove(localIPAddress.LastIndexOf("."))))
                        {
                            listIP.Add(listArp[i]);
                        }
                    }
    
                    // Remove local IP from IP list
                    listIP.RemoveAt(0);
    
                    p.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("IPInfo: Error Retrieving 'arp -a' Results", ex);
                }
                finally
                {
                    if (p != null)
                    {
                        p.Close();
                    }
                }
    
                return listIP;
            }

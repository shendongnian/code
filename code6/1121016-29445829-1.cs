    IEnumerable<IPAddress> GetIP()
            {
                foreach (var ip in Dns.GetHostEntry(Dns.GetHostName()).AddressList.Where(ip => ip.AddressFamily == AddressFamily.InterNetwork))
                {
                    yield return ip;
                }
            }
    
    string GetServer(string dataSource)
            {
                return dataSource.Split('\\').First().Split(',').First().Split(':').Last();
            }

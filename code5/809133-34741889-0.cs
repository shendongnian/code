    Try this:
     using (Microsoft.Web.Administration.ServerManager sm = Microsoft.Web.Administration.ServerManager.OpenRemote("localhost"))
            {
     int counter = 0;
            string[] ipAddress = new string[10];
            string[] sites = new string[10];
            List<Tuple<string, string>> mylist = new List<Tuple<string, string>>();
                foreach (var site in sm.Sites)
                {
                    sites[counter] = site.Name;
                    
                    foreach(var bnd in site.Bindings)
                    {
                        ipAddress[counter] = bnd.EndPoint != null ? bnd.EndPoint.Address.ToString() : "";                         
                    }                    
                    mylist.Add(Tuple.Create(sites[counter], ipAddress[counter]));
                    counter++;                    
                }
            }

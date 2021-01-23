    public DateTime findlastlogon(string userName)
        {
            DirectoryContext context = new DirectoryContext(DirectoryContextType.Domain, "domainName");
            DateTime latestLogon = DateTime.MinValue;
            DomainControllerCollection dcc = DomainController.FindAll(context);
            Parallel.ForEach(dcc.Cast<object>(), dc1 =>
                    {
                        DirectorySearcher ds;
                        DomainController dc = (DomainController)dc1;
                        using (ds = dc.GetDirectorySearcher())
                        {
                            try
                            {
                                ds.Filter = String.Format(
                                  "(sAMAccountName={0})",
                                  userName
                                  );
                                ds.PropertiesToLoad.Add("lastLogon");
                                ds.SizeLimit = 1;
                                SearchResult sr = ds.FindOne();
                                if (sr != null)
                                {
                                    DateTime lastLogon = DateTime.MinValue;
                                    if (sr.Properties.Contains("lastLogon"))
                                    {
                                        lastLogon = DateTime.FromFileTime(
                                          (long)sr.Properties["lastLogon"][0]
                                          );
                                    }
                                    if (DateTime.Compare(lastLogon, latestLogon) > 0)
                                    {
                                        latestLogon = lastLogon;
                                        //servername = dc1.Name;
                                    }
                                }
                            }
                            catch (Exception)
                            {
                            }                          
                        }
                    });
            return latestLogon;
        }

    /// <summary>
    /// Call everytime a page view is requested
    /// </summary>
    private static void DoRequest(string ipAddress)
    {
        using (var db = new MainContext())
        {
            var rec = db.v2SiteIPRequests.SingleOrDefault(c => c.IPAddress == ipAddress);
            if (rec == null)
            {
                // Catch insert race condition for PK violation.  Especially susceptible when being hammered by requests from 1 IP
                try
                {
                    var n = new v2SiteIPRequest {IPAddress = ipAddress, Requests = 1};
                    db.v2SiteIPRequests.InsertOnSubmit(n);
                    db.SubmitChanges();
                }
                catch (Exception e)
                {
                    try
                    {
                        // Can't reuse original context as it caches
                        using (var db2 = new MainContext())
                        {
                            var rec2 = db2.v2SiteIPRequests.Single(c => c.IPAddress == ipAddress);
                            rec2.Requests++;
                            db2.SubmitChanges();
                            if (rec2.Requests >= Settings.MAX_REQUESTS_IN_INTERVAL)
                            {
                                BanIP(ipAddress);
                            }
                        }
                    }
                    catch (Exception ee)
                    {
                        // Shouldn't reach here
                        Error.Functions.NewError(ee);
                    }
                }
            }
            else
            {
                rec.Requests++;
                db.SubmitChanges();
                // Ban?
                if (rec.Requests >= Settings.MAX_REQUESTS_IN_INTERVAL)
                {
                    BanIP(ipAddress);
                }
            }
        }
    }

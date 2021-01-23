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
                // Catch insert race condition for PK violation
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
                        Error.Functions.NewError(ee, "DoRequest Inner Catch");
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

     List<ReportPermissions> finalizedItems = new List<ReportPermissions>();
                foreach (ReportPermissions rp in l)
                {
                    //Check to see if record for this user exists
                    if (!finalizedItems.Any(x => x.CwsId == rp.CwsId))
                    {
                        // if it doesn't exist, get it
                        ReportPermissions perm = new ReportPermissions();
                        perm.CwsId = rp.CwsId;
                        perm.Reports = string.Join(",", l.Where(x => x.CwsId == rp.CwsId).Select(x => x.Reports).Distinct());
                        perm.Regions = string.Join(",", l.Where(x => x.CwsId == rp.CwsId).Select(x => x.Regions).Distinct());
                        finalizedItems.Add(perm);
                    }
                }
                l= finalizedItems;

    var systemInformation = (from r in entities.Resources
                             let serverNos = r.Where(a => String.IsNullOrEmpty(a.ASSETTAG) && (a.SystemInfo.ISSERVER == true ) && !(notservers.Contains(a.SystemInfo.MODEL.Trim().ToLower())))
                             let vmnos = r.[...]
                             select new SystemInformation 
                                        {
                                            IT360ServerNo = serverNos.Count(),
                                            IT360VMNo = vmnos.Count(),
                                            [...]
                                        }).First();

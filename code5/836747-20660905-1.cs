            using (var faxHistory = new waldenEntities())
            {
                var query = from c in faxHistory.FaxesSendServers.Where(p => p.UserID.Contains("walden"))
                            select new
                            {
                                c.SendID,
                                c.Status,
                                c.FaxName,
                                c.CreateTime,
                                c.CompletionTime,
                                c.PageCount,
                                c.RecipientName,
                                c.Notes
                            };
                var faxHistoryJson = from c in query.AsEnumerable()
                        select new
                        {
                            c.SendID,
                            c.Status,
                            c.FaxName,
                            CreateTime = c.CreateTime.ToShortDateString() + " " + c.CreateTime.ToShortTimeString(),
                            c.CompletionTime,
                            c.PageCount,
                            c.RecipientName,
                            c.Notes
                        };
                DataSourceResult result = faxHistoryJson.ToDataSourceResult(request);
                return Json(result, JsonRequestBehavior.AllowGet);
            }

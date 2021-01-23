                    int year = DateTime.Now.Year;
                    DateTime sdate = new DateTime(year, DateTime.Now.Month - 1, 1);
                    DateTime edate = new DateTime(year, DateTime.Now.Month, 1);
                   Emails.Item[] created = Emails.collection.Where(t => t.createdon.HasValue && (t.createdon.Value >= sdate && t.createdon.Value < edate)).OrderByDescending(y => y.createdon).ToArray();
                    List<Emails.Item> deleted = Emails.collection.Where(t => t.deletedon.HasValue && (t.deletedon.Value >= sdate && t.deletedon.Value < edate)).OrderByDescending(y => y.deletedon).ToList();
                    List<Emails.Item> ex = new List<Emails.Item>();
                    foreach (Emails.Item t in created)
                    {
                        Emails.Item d = deleted.FirstOrDefault(y => y.deletedon.Value >= t.createdon.Value);
                        if (d != null && t.createdon.Value <= d.deletedon.Value)
                        {
                            deleted.Remove(d);
                            ex.Add(t);
                        }
                    }
                    //System.Windows.MessageBox.Show(created.Count().ToString() + " / " + deleted.Count().ToString() + " / " + ex.Count().ToString());
                    var qry = Emails.collection.Where(t => 
                        t.deletedon.HasValue ?
                        t.deletedon.Value >= sdate :
                        t.createdon.Value < edate
                        ).Except(ex).ToArray()
                        .OrderBy(t => t.lastname).OrderBy(t => t.firstname).GroupBy(x => x.company, (key, group) => new { Company = key, Items = group });

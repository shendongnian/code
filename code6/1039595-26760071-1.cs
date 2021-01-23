    using (MyDbContext db = new MyDbContext())
            {
                foreach (var market in marketsList)
                {
                    var existingMarket =
                        db.Markets.FirstOrDefault(x => x.ProjectID == market.ProjectID && x.Year == market.Year);
                    if (existingMarket != null)
                    {
                        //Set properties for existing market
                         existingMarket.Year == market.Year
                         //etc
                    }
                    else
                    {
                        db.Markets.Add(market);
                    }
                    db.SaveChanges();
                }
            }

    public IQueryable<xTourist> GetxTouristByCategory(string category)
            {
                var now = System.DateTime.MinValue;
                switch (category)
                {
                    case "arrival":
                        now = System.DateTime.Now.AddDays(-3);
                        return db.xTourist.AsQueryable().Where(p => p.Room == null).Where(p => p.Arrival >= now).OrderByDescending(p => p.Arrival);
                        
                    default:
                        now = System.DateTime.Today;
                        return db.xTourist.AsQueryable().Where(p => p.Room != null).Where(p => p.Arrival >= now).OrderByDescending(p => p.Arrival);
                }
            }

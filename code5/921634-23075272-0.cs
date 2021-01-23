        enum ECategory { Arrival, Inhouse };
    
        public IQueryable<xTourist> GetxTouristByCategory(ECategory category)
                {
    
                    return (category = ECategory.Arrival) ?
                           db.xTourist.AsQueryable().Where(p => p.Room == null).Where(p => p.Arrival >= System.DateTime.Now.AddDays(-3)).OrderByDescending(p => p.Arrival)
                         : db.xTourist.AsQueryable().Where(p => p.Room != null).Where(p => p.Arrival >= System.DateTime.Today).OrderByDescending(p => p.Arrival);
                    }
                }

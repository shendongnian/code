        [WebGet]
        public IQueryable<Thing> GetThingsByID(string ids)
        {
            return CurrentDataSource.Things.Where(x => ids.Contains(x.ThingID.ToString())).AsQueryable();
        }

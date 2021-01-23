        // GET tables/BPNews
        public IQueryable<BPNews> GetAllBPNews()
        {
            return Query().Where(x => x.DateStart <= DateTime.Now && x.DateEnd >= DateTime.Now);
        }

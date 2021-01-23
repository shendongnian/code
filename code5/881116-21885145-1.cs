    public List<ProductionSchedule> GetBaseProductionSchedule(DateTime selectedDate)
        {
            var spaList = (from x in db.WO010032s
                           join y in db.MOP1042s on x.MANUFACTUREORDER_I equals y.MANUFACTUREORDER_I into x_y
                           where x.STRTDATE == selectedDate && (x.MANUFACTUREORDERST_I == 2 || x.MANUFACTUREORDERST_I == 3)
                           from y in x_y.DefaultIfEmpty()
                           select new ProductionSchedule()
                           {
                               MO = x.MANUFACTUREORDER_I,
                               BOMNAME = x.BOMNAME_I,
                               SpaModel = x.ITEMNMBR,
                               MoldType = GetMoldType(x.ITEMNMBR.Trim()),
                               SerialNumber = y.SERLNMBR,
                               Difficulty = GetModelDifficulty(x.ITEMNMBR)
                           }).ToList();
            return spaList.OrderByDescending(x => x.Difficulty).ToList();
        }
        public string GetMoldType(string model)
        {
            return db.SkuModelDatas.Where(x => x.Value == model).Select(x => x.MoldType).FirstOrDefault();
        }
        public decimal GetModelDifficulty(string model)
        {
            decimal difficulty = (String.IsNullOrEmpty(model)) ? 0M : Convert.ToDecimal(db.SkuModelDatas.Where(x => x.Value == model.Trim()).Select(x => x.Difficulty).FirstOrDefault());
            return difficulty;
        }

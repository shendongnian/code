        public async Task<List<DailyStat>> GetLast31DaysReport(string id)
        {
            var mc = new MongoClient(_url);
            var db = mc.GetDatabase(DbName);
            var collection = db.GetCollection<Reading>(CollectionName);
            DateTime from = DateTime.Now.AddDays(-31);
            DateTime to = DateTime.Now;
            var output = await collection.Aggregate()
                .Match(r => r.SensorId == id)
                .Match(r => r.Date <= to)
                .Match(r => r.Date >= to.AddDays(-31))
                .Group(r => new { groupedYear = r.Date.Year, groupedMonth = r.Date.Month, groupedDay = r.Date.Day }, g =>
                    new {
                        Key = g.Key,
                        avgValue = g.Average(x => x.Value),
                        minValue = g.Min(x => x.Value),
                        maxValue = g.Max(x => x.Value)
                    })
                .Project(r => new DailyStat()
                    {
                        Day = r.Key.groupedDay,
                        Month = r.Key.groupedMonth,
                        Year = r.Key.groupedYear,
                        Value = r.avgValue,
                        MinValue = r.minValue,
                        MaxValue = r.maxValue
                    })
                .ToListAsync().ConfigureAwait(false);
            var returnList = new List<DailyStat>();
            while (returnList.Count < 31)
            {
                var value = output.FirstOrDefault(rec => rec.Day == from.Day && rec.Month == from.Month && rec.Year == from.Year);
                returnList.Add(value ?? new DailyStat() { Month = from.Month, Year = from.Year, Day = from.Day, Value = 0, MaxValue = 0, MinValue = 0 });
                from = from.AddDays(1);
            }
            return returnList;
        }

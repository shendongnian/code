         var result = from s in entitiesModel.TvysFuelTankDatas
                               orderby s.Datetime ascending
                               group s by new { y = s.Datetime.Year, m = s.Datetime.Month + "/", d = s.Datetime.Day + "/" } into g
                               select new WellDrillData { Date = Convert.ToDateTime(g.Key.d.ToString() + g.Key.m.ToString() + g.Key.y.ToString()), Depth = (double)g.Sum(x => x.Difference) };
                  List<WellDrillData> dailyFuelConsumptions = result.ToList();

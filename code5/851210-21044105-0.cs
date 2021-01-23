    public ActionResult GetChartData(int? id)
        {
            if (id == null)
            {
                return Json(null);
            }
            var EODData = _unitOfWork.Repository<EODSecurityData>()
                .Query()
                .OrderBy(q => q
                    .OrderBy(c => c.EODDate))
                .Filter(x => x.ListedSecurityId == id)
                .Get().ToList()
                .Select(r => new { date= r.EODDate, r.DayOpen, r.DayHigh, r.DayLow, r.DayClose });
            List<object> output = new List<object>();
            foreach (var dataElement in EODData)
            {
                output.Add(new object[] { ToJsonTicks(dataElement.date), dataElement.DayOpen, dataElement.DayHigh, dataElement.DayLow, dataElement.DayClose });
            }
            return Json(output, JsonRequestBehavior.AllowGet);
        }
        
        public long ToJsonTicks(DateTime value)
        {
            return (value.ToUniversalTime().Ticks - ((new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).Ticks)) / 10000;
        }

            public List<DateTime> getDaysOpen(int numberOfDays, DateTime start)
        {
            List<byte> openDays = this.getOpeningHoursDays();
            List<DateTime> nextNOpenDays = new List<DateTime>();
            
            while (nextNOpenDays.Count < numberOfDays)
            {
                if (openDays.Contains(Convert.ToByte(start.DayOfWeek)))
                    nextNOpenDays.Add(start);
                start = start.AddDays(1);
            }
            return nextNOpenDays;
        }
        public List<byte> getOpeningHoursDays()
        {
            return db.OpeningHours.Where(oh => oh.LocationId == this.Id).Select(oh => oh.DateOfWeek).ToList();
        }

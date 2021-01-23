    var q = from r in Readings
            group r by r.Meter_Id into rGroup
            let MaxReading = rGroup.OrderByDescending(x => x.TimestampLocal).First()
            let MinReading = rGroup.OrderBy(x => x.TimestampLocal).First()
            select new
            {
                Meter_Id = rGroup.Key,
                MaxReading = MaxReading.Id,
                MaxReadingTime = MaxReading.TimestampLocal,
                MinReading = MinReading.Id,
                MinReadingTime = MinReading.TimestampLocal,
                Difference = MaxReading.Value - MinReading.Value
            };

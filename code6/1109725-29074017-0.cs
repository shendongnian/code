            var minBorder = new DateTime(2015, 3, 16, 00, 00, 00);
            var maxBorder = new DateTime(2015, 3, 16, 23, 59, 00);
            var times = new List<DateTime>();
            times.Add(minBorder);
            foreach (var at in availableTimes) {
                times.Add(at.StartDate);
                times.Add(at.EndDate);
            }
            times.Add(maxBorder);

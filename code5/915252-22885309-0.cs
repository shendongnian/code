            var startDate = new DateTime(2013, 2, 1);
            var endDate = new DateTime(2014, 2, 1);
            var totalDays = endDate.Subtract(startDate).TotalDays;
            // Determine the total number of weeks.
            var totalWeeks = totalDays / 7;
            // Initialize the current date to the start date
            var currDate = startDate;
            // Process each of the weeks
            for (var week = 0; week < totalWeeks; week++)
            {
                // Do something
                // Get the next date
                currDate = currDate.AddDays(7);
            }

     DateTime? startDate = DateTime.Now;
            DateTime? endDate = DateTime.Now.AddDays(5);
           
            long differenceOfDays = 0;
            if (startDate.HasValue && endDate.HasValue)
                differenceOfDays = endDate.Value.Ticks - startDate.Value.Ticks;
            int daysDifference = new TimeSpan(differenceOfDays).Days;

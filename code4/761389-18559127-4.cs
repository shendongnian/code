            TimeSpan ts = DateTime.Now.TimeOfDay;
            foreach (DateTime date in theDates)
            {
                long diff = Math.Abs(ts.Ticks - date.TimeOfDay.Ticks);
                if (diff < min)
                {
                    min = diff;
                    closestDate = date;
                }
            }

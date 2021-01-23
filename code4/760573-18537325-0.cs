     private List<DateTime> RemoveItems(List<DateTime> times)
            {
                var newtimes = new List<DateTime>();
    
                var previoustime = new DateTime();
                
                var firsttime = times[0];
    
                newtimes.Add(firsttime);
                
                foreach (var time in times)
                {
                    if (firsttime == time)
                    {
                        previoustime = time;
                        continue;
                    }
    
                    if ((time - previoustime) > new TimeSpan(0,0,1,30))
                    {
                        newtimes.Add(time);
                    }
    
                    previoustime = time;
                }
    
                return newtimes;
            }

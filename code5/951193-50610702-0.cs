     private TimeSpan calculateVariance(string dateString)
            {
                DateTime clientHour = Convert.ToDateTime(dateString);
                DateTime serverHour = DateTime.Now.ToLocalTime();
                TimeSpan timeVariance = clientHour - serverHour;
    
                TimeSpan roundedTimeVariance;
              
                //ROUND VARIANCE TO THE NEAREST 15 minutes AND RETURN AS EITHER A POSITIVE OR NEGATIVE TimeSpan Object
                if (timeVariance.Minutes > 52)
                {
                    roundedTimeVariance = new TimeSpan(timeVariance.Hours + 1, 0, 0);
                }
                else if (timeVariance.Minutes > 37)
                {
                    roundedTimeVariance = new TimeSpan(timeVariance.Hours, 45, 0);
                }
                else if (timeVariance.Minutes > 22)
                {
                    roundedTimeVariance = new TimeSpan(timeVariance.Hours, 30, 0 );
                }
                else if (timeVariance.Minutes > 7)
                {
                    roundedTimeVariance = new TimeSpan(timeVariance.Hours, 15, 0);
                }
                else
                {
                    roundedTimeVariance = new TimeSpan(timeVariance.Hours, 0, 0);
                }
                
                return roundedTimeVariance;
            }
  

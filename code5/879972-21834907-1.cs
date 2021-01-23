            DateTime d = DateTime.Now;
            DateTime d2 = DateTime.Now.AddMinutes(-28938923);
            int years = d.Year - d2.Year;
            int months = d.Month - d2.Month;
            int days = d.Day - d2.Day;
            if (days < 0)
            { 
                // borrow a month
                months--;
                // use your brain power to pick the correct month.  I have not thought this step out.
                days += DateTime.DaysInMonth(d.Month);  
            }
            if (months < 0)
            { 
                // borrow a year
                years--;
                months += 12;
            }

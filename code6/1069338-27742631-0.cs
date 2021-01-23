         private struct DateResult
        {
            public int years;
            public int months;
            public int days;
        }
        private DateResult Date_Difference(DateTime d1, DateTime d2)
        {
            DateResult d_r;
            d_r.years = 0;
            d_r.months = 0;
            d_r.days = 0;
            DateTime frm_date, to_Date;
            int key=0;
            if (d1 > d2)
            {
                frm_date = d2;
                to_Date = d1;
            }
            else
            {
                frm_date = d1;
                to_Date = d2;
            }
            if (frm_date.Day > to_Date.Day) //10  5  //7  24
            {
                key = month_day[frm_date.Month - 1];
                if (key == -1)
                {
                    if (DateTime.IsLeapYear(frm_date.Year))
                        key = 29;
                    else
                        key = 28;
                }                
            }
            if (key == 0)
            {
                d_r.days = to_Date.Day - frm_date.Day;
            }
            else
            {
                d_r.days = (to_Date.Day + key) - frm_date.Day;
                key = 1;
            }
            if ((frm_date.Month+key) > to_Date.Month)
            {
                d_r.months = (to_Date.Month + 12) - (frm_date.Month + key);
                key = 1;
            }
            else
            {
                d_r.months = to_Date.Month - (frm_date.Month+key);
                key=0;
            }
            d_r.years = to_Date.Year - (frm_date.Year+key);
            return d_r; 
        }

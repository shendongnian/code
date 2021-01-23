    private string GetDatesOfSundays(DateTime DatMonth)  
        {  
            string sReturn = "";  
            int iDayOffset = DatMonth.Day - 1;  
            DatMonth = DatMonth.AddDays(System.Convert.ToDouble(-DatMonth.Day + 1));  
            DateTime DatMonth2 = DatMonth.AddMonths(1).AddDays(System.Convert.ToDouble(-1));  
            while (DatMonth < DatMonth2)  
            {  
                if (DatMonth.DayOfWeek == System.DayOfWeek.Sunday)  
                {  
                    if (sReturn.Length > 0) sReturn += ",";  
                    sReturn += DatMonth.ToShortDateString();  
                }  
                DatMonth = DatMonth.AddDays(1.0);  
            }  
            return sReturn;  
        }   

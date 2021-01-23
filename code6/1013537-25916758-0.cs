        DateTime FormatDateTime(string Start_Date)
        {
            DateTime startDate = new DateTime();
            Start_Date = Start_Date.Trim();
            char dateSeperator = '_';
            char timeSeperator = ':';
            char dateTimeSeperator = ' ';
            string temp = "";
            int dateCounter = 0;
            int timeCounter = 0;
            for (int i = 0; i < Start_Date.Length; i++)
            {
                if (dateSeperator == Start_Date[i])
                {
                    if (0 == dateCounter)
                    {
                        startDate.AddDays(System.Convert.ToInt32(temp) - startDate.Day);
                    }
                    else if (1 == dateCounter)
                    {
                        startDate.AddMonths(System.Convert.ToInt32(temp) - startDate.Month);
                    }
                    dateCounter++;
                    temp = "";
                }
                else
                    if (dateTimeSeperator == Start_Date[i])
                    {
                        startDate.AddYears(System.Convert.ToInt32(temp) - startDate.Year);
                        temp = "";
                    }
                    else
                        if (timeSeperator == Start_Date[i])
                        {
                            if (0 == timeCounter)
                            {
                                startDate.AddHours(System.Convert.ToInt32(temp) - startDate.Hour);
                            }
                            else if (1 == timeCounter)
                            {
                                startDate.AddMinutes(System.Convert.ToInt32(temp) - startDate.Minute);
                            }
                            else if (2 == timeCounter)
                            {
                                startDate.AddSeconds(System.Convert.ToInt32(temp) - startDate.Second);
                            }
                            timeCounter++;
                            temp = "";
                        }
                        else
                        {
                            temp += Start_Date[i];
                            if (Start_Date.Length == i + 1)
                            {
                                startDate.AddMilliseconds(System.Convert.ToInt32(temp) - startDate.Millisecond);
                            }
                        }
            }
            return startDate;
        }

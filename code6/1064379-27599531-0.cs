     private void getDifference_Click(object sender, EventArgs e)
        {
            DateTime messageTime = Convert.ToDateTime("02/20/2013 6:21:12 PM");
            DateTime nowDate = DateTime.Now;
            TimeSpan diff = TimeSpan.Zero;
            if (messageTime > nowDate)
                diff = messageTime - nowDate;
            if (messageTime < nowDate)
                diff = nowDate - messageTime;
            int intSeconds = diff.Seconds;
            int intMinutes = diff.Minutes;
            int intDays = diff.Days;
            int intMonths = 0;
            int intYear = 0;
            if (intDays > 31)
            {
                intMonths = MonthDifference(nowDate, messageTime);
            }
            if (intMonths > 12)
            {
                string strYear = Convert.ToString(intMonths / 12);
                string[] strParts = strYear.Split('.');
                intYear = Convert.ToInt32(strParts[0].ToString());
            }
            string lastMessageTime = "";
            if (intYear == 0)
            {
                if (intMonths == 0)
                {
                    if (intDays == 0)
                    {
                        if (intMinutes == 0)
                        {
                            lastMessageTime = "just now";
                        }
                        else
                        {
                            if (intMinutes == 1)
                                lastMessageTime = "1 minute ago";
                            else
                                lastMessageTime = intMinutes + " minutes ago";
                        }
                    }
                    else
                    {
                        if (intDays == 1)
                            lastMessageTime = "1 day ago";
                        else
                            lastMessageTime = intDays + " days ago";
                    }
                }
                else
                {
                    if (intMonths == 1)
                        lastMessageTime = "1 month ago";
                    else
                        lastMessageTime = intMonths + " months ago";
                }
            }
            else
            {
                if (intYear == 1)
                    lastMessageTime = "1 year ago";
                else
                    lastMessageTime = intYear + " years ago";
            }
        }
        public int MonthDifference(DateTime nowDate, DateTime messageTime)
        {
            return (nowDate.Month - messageTime.Month) + 12 * (nowDate.Year - messageTime.Year);
        }

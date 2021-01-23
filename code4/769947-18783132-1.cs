     private static DateTime ExtractDateTime(string str)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ru");
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("ru");
            string[] date = str.Split(',');
            string[] needeedate = {""};
            needeedate[0] = date[0];
            for (var i = 1; i < date.Length; i++)
            {
                string[] temp1 = date[i].Split(' ');
                foreach (var temp in from s in temp1 where !String.IsNullOrEmpty(s) select needeedate[0] + " , " + s)
                {
                    try
                    {
                        var res = DateTime.Parse(temp);
                        needeedate[0] = temp;
                    }
                    catch (Exception)
                    {
                        return DateTime.Parse(needeedate[0]);
                    }
                }
            }
            return new DateTime();
        }

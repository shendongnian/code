    public static bool IsValidDate(string date)
        {
            var regex = new Regex("^\\d{ 4 } /\\d{ 2}/\\d{ 2}$");
            var arrPattern = new[] {
                new Regex("^\\d{4}/\\d{2}/\\d{2}$"),
                new Regex("^\\d{ 4 } /\\d{ 2}/\\d{ 1}$"),
                new Regex("^\\d{ 4 } /\\d{ 1}/\\d{ 2}$"),
                new Regex("^\\d{ 4 } /\\d{ 1}/\\d{ 1}$"),
                new Regex("^\\d{ 2 } /\\d{ 2}/\\d{ 2}$"),
                new Regex("^\\d{ 2 } /\\d{ 2}/\\d{ 1}$"),
                new Regex("^\\d{ 2 } /\\d{ 1}/\\d{ 2}$"),
                new Regex("^\\d{ 2 } /\\d{ 1}/\\d{ 1}")
            };
            const int kabise = 1387;
            var year = 0;
            var mounth = 0;
            var day = 0; var flag = false;
            foreach (var t in arrPattern)
            {
                if (t.IsMatch(date))
                    flag = true;
            }
            if (flag == false) return flag;
            //جدا کننده تاریخ می تواند یکی از این کاراکترها باشد
            var splitDate = date.Split('/','-',':');
            year = Convert.ToInt32(splitDate[0]);
            mounth = Convert.ToInt32(splitDate[1]);
            day = Convert.ToInt32(splitDate[2]);
            if (mounth > 12 || mounth <= 0)
                flag = false;
            else
            {
                if (mounth< 7)
                {
                    if (day > 31)
                    {
                        flag = false;
                    }
                }
                if (mounth != 12) return flag;
                var t = (year - kabise) % 4;
                if ((year - kabise) % 4 == 0)
                {
                    if (day >= 31)
                        flag = false;
                }
                else if (day >= 30)
                    flag = false;
            }
            return flag;
        }

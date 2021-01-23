                DateTime currentDate = DateTime.Now;
                String strDate = "01/01/41";
                DateTime userDate=DateTime.ParseExact(strDate, "dd/MM/yy", System.Globalization.CultureInfo.InvariantCulture);
                currentDate=currentDate.AddYears(30);
                if ((userDate.Year%100) > (currentDate.Year%100))
                {
                    strDate = strDate.Insert(6, "19");
                }
                else
                {
                    strDate = strDate.Insert(6, "20");
                }
                DateTime newUserDate = DateTime.ParseExact(strDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

            var list = new List<string> {"12/31/2015", "31/12/2015", "2015-12-31"};
            var allowedCultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            foreach (string s in list)
            {
                DateTime dt;
                foreach (CultureInfo culture in allowedCultures)
                {
                    if (DateTime.TryParse(s, culture, DateTimeStyles.None, out dt))
                    {
                        Console.WriteLine("{0} - {1}", culture.DisplayName, dt.ToShortDateString());
                        break;
                    }
                }
            }

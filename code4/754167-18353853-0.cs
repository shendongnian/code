    public  static string ConvertToDate(string persianDate)
        {
            try
            {
                if (persianDate.Length != 10)
                {
                    char a = Convert.ToChar(persianDate.Substring(4, 1));
                    char b = Convert.ToChar(persianDate.Substring(6, 1));
                    if (a == '/' && b == '/')
                    {
                        if (persianDate.Length == 9)
                        {
                            persianDate = persianDate.Insert(5, '0'.ToString());
                        }
                        if (persianDate.Length == 8)
                        {
                            persianDate = persianDate.Insert(5, '0'.ToString());
                            persianDate = persianDate.Insert(8, '0'.ToString());
                        }
                    }
                    char c = Convert.ToChar(persianDate.Substring(7, 1));
                    if (c == '/')
                    {
                        if (persianDate.Length == 9)
                        {
                            persianDate = persianDate.Insert(8, '0'.ToString());
                        }
                    }
                }
                return persianDate;
            }
            catch (Exception ex)
            {
               ExceptionkeeperBll.LogFileWrite(ex);
                return null;
            }
        }
    }

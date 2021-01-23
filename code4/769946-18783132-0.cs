     private static DateTime ExtractDateTime(string str)
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ru");
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("ru");
    
               var date= str.Split(',');
    
                string needeedate = "";
    
                needeedate = date[0];
                for (int i = 1; i < date.Length; i++)
                {
                    var temp1 = date[i].Split(' ');
    
                    foreach (var s in temp1)
                    {
                        if (!String.IsNullOrEmpty(s))
                        {
                            string temp = needeedate + " , " + s;
    
                            try
                            {
                                var res = DateTime.Parse(temp);
                                needeedate = temp;
                            }
                            catch (Exception)
                            {
                                return DateTime.Parse(needeedate);
                            }
                        }
                    }
                    
                }
                
                return new DateTime();
            }

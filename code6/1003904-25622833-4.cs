    public static int CheckNumberOfEnters()
            {
                int result = 0;
                int counter = 0;
                DateTime TimeCounter;
                try
                {
    
                    if (HttpContext.Current.Session["counter"] != null)
                    {
                        counter = int.Parse(HttpContext.Current.Session["counter"].ToString());
                        counter++;
                        HttpContext.Current.Session["counter"] = counter;
                    }
                    else
                    {
                        HttpContext.Current.Session.Add("counter", counter);
                    }
                    if (counter < int.Parse(ConfigurationManager.AppSettings["LoginTry"].ToString()) + 1)
                    {
                        result = 1;
                        HttpContext.Current.Session["counter"] = counter;
                    }
                    else
                    {
                        if (counter < int.Parse(ConfigurationManager.AppSettings["LoginTry"].ToString()) + 4)
                        {
                            result = -1;
                            HttpContext.Current.Session["counter"] = counter;
                        }
                        else
                        {
                            HttpContext.Current.Session["counter"] = counter;
                            if (HttpContext.Current.Session["TimeCounter"] != null)
                            {
                                TimeCounter = DateTime.Parse(HttpContext.Current.Session["TimeCounter"].ToString());
                            }
                            else
                            {
                                HttpContext.Current.Session.Add("TimeCounter", DateTime.Now);
                                TimeCounter = DateTime.Now;
                            }
                            TimeSpan ts = DateTime.Now - TimeCounter;
                            if (ts.TotalMinutes >= int.Parse(ConfigurationManager.AppSettings["LogINTryMinuts"].ToString()))
                            {
                                HttpContext.Current.Session["TimeCounter"] = null;
                                result = 1;
                                counter = 0;
                                HttpContext.Current.Session["counter"] = counter;
                            }
                            else
                            {
                                result = 0;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErrorLoging.InsertLogError("BasePage.aspx", "CheckNumberOfEnters fail", ex.ToString(), "", 0);
                }
                return result;
            }

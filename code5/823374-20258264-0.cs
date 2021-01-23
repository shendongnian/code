    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
                    int factor;
                    if (factor >= 60)
                    {
                        int b = factor / 60;
                        factor = factor % 60;
                        string time = Convert.ToString(b + ":" + factor);
    
                        if (factor < 10)
                        {
                            timer = TimeSpan.ParseExact(time, @"h\:m", null);
                        }
                        else
                        {
                            timer = TimeSpan.ParseExact(time, @"h\:mm", null);
                        }
                    }
                    else if (factor > 9 && factor < 60)
                    {
                        timer = TimeSpan.ParseExact(factor.ToString(), "mm", null);
                    }
                    else
                    {
                        timer = TimeSpan.ParseExact("0" + factor.ToString(), "mm", null);
    
    
                    }
                    HidH.Value = Convert.ToString(timer.Hours);
    
    
    
                    HidM.Value = Convert.ToString(timer.Minutes);
    
    
     
                    HidS.Value = Convert.ToString(timer.Seconds);
        }
    }

    minremain=1200000; //Should be in milisecond
    timerplurg.satrt();
    
     private void timerplurg_Tick(object sender, EventArgs e)
            {
          minremain = minremain - 1000; //substring One second from total time
                string Sec = string.Empty;
                if (minremain <= 0)
                {
                    lblpurgingTimer.Text = "";
                    timerplurg.Stop();
                    return;
                }
                else
                {
            var timeSpan =   TimeSpan.FromMilliseconds(Convert.ToDouble(minremain));
    
                    var seconds = timeSpan.Seconds;
                     if (seconds.ToString().Length.Equals(1))
                    {
                        Sec = "0" + seconds.ToString();
                    }
                    else
                    {
                        Sec = seconds.ToString();
                    }
                   
                    string Totaltime = "Remaing Second: " + Sec;
                    lblpurgingTimer.Text = Totaltime;
                }

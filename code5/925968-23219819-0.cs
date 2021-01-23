            foreach (GridDataItem item in RadGrid1.Items)
            {
                DateTime starttime = DateTime.ParseExact((item.FindControl("Strat_TimeLabel") as Label).Text, "H:mm:ss", System.Globalization.CultureInfo.CurrentCulture);
                DateTime nowtime = System.DateTime.Now;
                TimeSpan ts = new TimeSpan();
                ts = starttime - nowtime;
                System.Web.UI.Timer).Parent.Parent.Parent.Parent as GridDataItem;
                if (ts.Seconds >= 0 && ts.Minutes > 0)
                {
                    DateTime d = new DateTime(2000, 01, 01, ts.Hours, ts.Minutes, ts.Seconds);
                    (item.FindControl("lbltime") as Label).Text = d.ToString("H:mm:ss");
                }
                else
                {
                    (item.FindControl("lbltime") as Label).Text = "Complete";
                }   
            }

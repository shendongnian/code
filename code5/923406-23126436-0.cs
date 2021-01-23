    private void Page_Load(object sender, EventArgs e)
        {
            System.Threading.TimerCallback callback = new TimerCallback(AlertEvent);
            DateTime myDate=  mydate.AddHours(1);
            if (DateTime.Now < myDate)
            {
                var timer = new System.Threading.Timer(callback, null, myDate- DateTime.Now, TimeSpan.FromHours(24));
            }
    
        }
    
        private void AlertEvent(object obj)
        {
            string script = "<script type=\"text/javascript\">alert('THIS IS ALERT FROM C# TO JS');</script>";
       ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
        }

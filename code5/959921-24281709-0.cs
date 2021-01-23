        protected void Page_Load(object sender, EventArgs e)
        {
            this.DisableTime(new DateTime(2014,5,1),new DateTime(2014,10,1));
        }
    
        private void DisableTime(DateTime startTime, DateTime endTime)
        {
            var currentTime = DateTime.Now;
            if (currentTime > startTime && currentTime < endTime)
            {
                this.DropDownList1.Enabled = false;
            }
        }

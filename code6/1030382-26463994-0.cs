    protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                  
               
                DateTime time1 = DateTime.Parse(string.Format("{0:00}:{1:00}", TimeSelector1.Hour, TimeSelector1.Minute,TimeSelector1.AmPm));
                DateTime time2 = DateTime.Parse(string.Format("{0:00}:{1:00}", TimeSelector2.Hour, TimeSelector2.Minute, TimeSelector2.AmPm));
               
                mas.leaveapply(time1.ToShortTimeString(),time2.ToShortTimeString());
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('You Have Succesfully Applied For Leave ..!!');", true);
            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
            }
        }

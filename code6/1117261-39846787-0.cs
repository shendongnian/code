      protected void Page_Load(object sender, EventArgs e)
    {
         if(ViewState["counter"] != null)
             timer1.Interval = (int)ViewState["counter"];
         else
          {
             timer1.Interval = 30000; // Assuming the total time of the exam is 30 secs
              ViewState["countet"]=30000;
           }
    }

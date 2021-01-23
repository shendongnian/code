     form_load()
     {
     private string myDate="1999/12/12";
          
        // Declare a Date property of type string:
        public string Name
        {
            get 
            {
               return myDate; 
            }
            set 
            {
               myName = value; 
            }
     }
    private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
    {            
        ActivityScheduler frm1 = new ActivityScheduler();
        ActivityScheduler.myDate = frm.monthCalendar1.SelectionRange.Start.ToShortDateString()
        frm1.Show();
    } 

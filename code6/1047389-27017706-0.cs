    public partial class CalendarUserControl: UserControl
    {
       // this is code-behind of your user control
       public string Data
       {
          get {return txtData.Text;}
       }
    
       public DateTime CalendarDate
       {
          get {return Calendar1.SelectedDate;}
       }
    
       // same approach for drop down list ddlthings
    }

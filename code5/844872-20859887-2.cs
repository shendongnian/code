    private DateTime? date1;
    private DateTime? date2;
    private Int32? taskLength;
    
    public DateTime? Date1
    {
        get { return date1; }
        set 
        {
            if (date1 == value) return;
            date1 = value;
            NotifyPropertyChanged("Date1");
            if (taskLength != null && date1 != null)
            {  
                date2 = date1.AddDays(taskLength);  
                // by calling the backing property you don't hit the set 
                NotifyPropertyChanged("Date2");
                // anything bound will call the get 
            }
        }
    }

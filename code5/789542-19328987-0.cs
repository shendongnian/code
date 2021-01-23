    public DateTime? DaDate
    {
     get { return daDate; }
     set
     {
        if(value != daDate)
        {
         daDate = value;
         NotifyOfPropertyChange(() => DaDate);
        }
     }
    }

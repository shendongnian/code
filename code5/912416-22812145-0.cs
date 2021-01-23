    public event PropertyChangedEventHandler PropertyChanged;
    private void NotifyPropertyChanged(String propertyName)
    {
         if (PropertyChanged != null)
         {
             PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
         }
    }
    private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
    {
        //update source
        lock (_dateLock)
        {         
            MyDate = new DateTime(e.Start.Ticks);  
            NotifyPropertyChanged("MyDate"); 
        }         
    }
    private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
    {
        //Check if bottom region with current date clicked
        if (IsCurrentDateClikced())
        {             
            //update source    
            lock (_dateLock)
            {              
               MyDate = new DateTime(DateTime.Now.Ticks);
               NotifyPropertyChanged("MyDate");
            }
        }       
    }

    class Level2 : INotifyPropertyChanged
    {
        //Notify Property Changed Implementation from MSDN:
        public event PropertyChangedEventHandler PropertyChanged;
    
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
               PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        private int counter = 0;
        public int Counter
        {
           get { return counter; }
           set
           {
               counter = value;
               NotifyPropertyChanged();
           }
        }
    
        ...
        public void timer_Tick(object sender, EventArgs e)
        {
            Counter++;
        }
    }

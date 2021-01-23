    public int CurrentID
    {
       get { return currentID; }
       set 
       {
           currentID = value;
           NotifyPropertyChanged("CurrentID");
           NotifyPropertyChanged("PropertyOfAnItemInAList");
       }
    }

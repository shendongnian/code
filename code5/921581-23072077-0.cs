    private string name;
    private string address;
    
     public string Name
     {
         get { return name;}
         set { 
                name = value;
                OnNotifyPropertyChanged("Name");
             }
    
     }
    
     public string Address
     {
         get { return address; }
         set { 
                 address = value ;
                 OnNotifyPropertyChanged("Address");
              }
     }

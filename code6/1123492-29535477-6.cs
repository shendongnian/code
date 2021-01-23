    MyViewModel
    {
         private int _id;
         public int ID
         {
            get { return _id; }
            set { _id= value; OnPropertyChanged("_id"); }
         }
    
         Public void InitilizeMessenger()
         {
             Messenger.Default.Register(this,"To MyViewModel", (int id) => ID = id);
         }
         public MyViewModel()
         {
            InitilizeMessenger();
         }
    }

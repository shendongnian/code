    class PlayerData
    {
        public static PlayerData Instance = new PlayerData();
        private UserData data = new UserData();
        public UserData Data
        {
            get { return data; }
            set { data = value; }
        }
    }
    class UserData : INotifyPropertyChanged
    {
        private int myXP = 0;
        public int MyXP 
        { 
            get { return myXP; }
            set
            {
                myXP = value;
                RaiseProperty("MyXP");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaiseProperty(string property = null)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }

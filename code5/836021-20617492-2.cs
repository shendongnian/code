    public class MyViewModel : INotifyPropertyChanged
    {
        static Dictionary<int, string> users;
        //Lets say this is ur static dictionary
        public static Dictionary<int, string> Users
        {
            get
            {
                return users ?? (users = new Dictionary<int, string> { 
                {1,"User1"},
                {2,"User2"},
                {3,"User3"}
                });
            }
        }
        public MyViewModel()
        {
            //Fill the collection
            FileItems = new ObservableCollection<FileItem>
                {
                new FileItem{OwnerId=1},
                new FileItem{OwnerId=2},
                new FileItem{OwnerId=3},
                };
        }
        //This will be binded to the ItemSource of DataGrid
        public ObservableCollection<FileItem> FileItems { get; set; }
        //Selected Owner Id . Notify if TwoMode binding required
        int selectedOwnerId;
        public int SelectedOwnerId
        {
            get
            { return selectedOwnerId; }
            set { selectedOwnerId = value; Notify("SelectedOwnerId"); }
        }
        private void Notify(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }

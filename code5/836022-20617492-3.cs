    public class FileItem : INotifyPropertyChanged
    {
        int ownerId;
        public int OwnerId
        {
            get
            { return ownerId; }
            set { ownerId = value; Notify("OwnerId"); }
        }
        KeyValuePair<int, string> comboSelectedItem;
        //This will have ComboBox Selected Item If SO need it 
        public KeyValuePair<int, string> ComboSelectedItem
        {
            get { return comboSelectedItem; }
            set { comboSelectedItem = value; Notify("ComboSelectedItem"); }
        }
        //.... other properties
        //.....
        private void Notify(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }

        public class ViewModel: INotifyPropertyChanged
    {
        int tabSelectedIndex;
        //this will be bound to the SelectedIndex of Tabcontrol
        public int TabSelectedIndex
        {
            get { return tabSelectedIndex; }
            set { tabSelectedIndex = value;
                Notify("TabSelectedIndex"); 
            }
        }
        Visibility tabVisibility;
        //this will be binded to the Visibility of TabItem 
        public Visibility  TabVisibility
        {
            get { return tabVisibility; }
            set
            {
                tabVisibility = value;
                //this is the logic that will set firstTab selected when Visibility will be collapsed
            if (tabVisibility == Visibility.Collapsed)
            {
                tabSelectedIndex = 0;
                Notify("TabSelectedIndex");
            }
                Notify("TabVisibility"); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        void Notify(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }

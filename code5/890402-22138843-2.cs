    internal class TabViewModel : INotifyPropertyChanged
        {
            public void RaisePropertyChanged(string propertyname)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            private ObservableCollection<Tab> items;
    
            public ObservableCollection<Tab> Items
            {
                get { return items; }
                set { items = value; RaisePropertyChanged("Items"); }
            }
            public TabViewModel()
            {
                items = new ObservableCollection<Tab>();
                items.Add(new Tab() { Header = "Tab Item 1", Content = "This is content 1" });
                items.Add(new Tab() { Header = "Tab Item 2", Content = "This is content 2" });
                items.Add(new Tab() { Header = "Tab Item 3", Content = "This is content 3" });
                items.Add(new Tab() { Header = " ", Content = "" });
            }
        }
    
        public class Tab:INotifyPropertyChanged
        {
            private string header;
    
            public string Header
            {
                get { return header; }
                set { header = value; RaisePropertyChanged("Header"); }
            }
    
            private string content;
    
            public string Content
            {
                get { return content; }
                set { content = value; RaisePropertyChanged("Content"); }
            }
            public void RaisePropertyChanged(string propertyname)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
        }

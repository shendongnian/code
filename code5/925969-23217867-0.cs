    public class MyModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public int id { get {...} set { OnPropertyChanged("id"); } }
        public string Name { get {...} set { OnPropertyChanged("Name"); } }
        public MyModel Parent { get {...} set { OnPropertyChanged("Parent"); } }
        public ModelCollection Descendants { get {...} set { OnPropertyChanged("Descendants"); } }
        public ModelCollection Children { get {...} set { OnPropertyChanged("Children"); } }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

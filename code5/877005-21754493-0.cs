    public class Article : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
            
        public ObservableCollection<string> ImagePath = new ObservableCollection<string>();
        private string subject;
        public string Subject
        {
           get { return subject; }
           set { subject = value; RaiseProperty("Subject"); }
        }
        private string words;
        public string Words
        {
           get { return words; }
           set { words = value; RaiseProperty("Words"); }
        }
        public Article()
        {
           ImagePath.CollectionChanged += (sender, e) => { RaiseProperty("FirstImage"); };
        }
        public Uri FirstImage
        {
            get
            {
                 return new Uri(ImagePath.FirstOrDefault(), UriKind.Relative);
            }
        }
        public void RaiseProperty(string property = null)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }

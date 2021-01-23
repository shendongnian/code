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
        // public Uri FirstImage // this can work if your image is a content of your App
        // {
        //    get
        //    {
        //         return new Uri(ImagePath.FirstOrDefault(), UriKind.Relative);
        //    }
        // }
       public BitmapImage FirstImage // getter - BitmapImage
       {
            get
            {
               if (String.IsNullOrEmpty(ImagePath[0])) return null;
               BitmapImage temp = new BitmapImage();
               using (IsolatedStorageFile ISF = IsolatedStorageFile.GetUserStoreForApplication())
               using (IsolatedStorageFileStream file = ISF.OpenFile(ImagePath[0], FileMode.Open, FileAccess.Read))
                    temp.SetSource(file);
               return temp;
            }
        }
        public void RaiseProperty(string property = null)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }

    public class myClass: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
 
        private Uri imageUri;
        public Uri ImageUri
        {
            get
            {
                return imageUri;
            }
            set
            {
               imageUri = value;
               if(PropertyChanged != null)
               {
                   PropertyChanged(this, new PropertyChangedEventArgs("ImageUri"));
               }
            }
        }
    }

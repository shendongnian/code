    public class Images : INotifyPropertyChanged
    {
       public event PropertyChangedEventHandler PropertyChanged;
       private string imgSource = "";
       public string SetImgSource // setter - string
       {
          set
          {
            imgSource = value;
            RaiseProperty("GetImgSource");
          }
       }
       public BitmapImage GetImgSource // getter - BitmapImage
       {
         get
         {
            if (String.IsNullOrEmpty(imgSource)) return null;
            BitmapImage temp = new BitmapImage();
            using (IsolatedStorageFile ISF = IsolatedStorageFile.GetUserStoreForApplication())
              using (IsolatedStorageFileStream file = ISF.OpenFile(imgSource, FileMode.Open, FileAccess.Read))
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
    ObservableCollection<Images> myImg = new ObservableCollection<Images>();
    myList.ItemsSource = myImg; // somewhere

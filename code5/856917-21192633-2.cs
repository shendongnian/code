     public class YourTitleClass : INotifyPropertyChanged
     {
        private string _title;
        public string Title
        {
           get { return _title; }
           set
           {
              if (_title.Equals(value))
                 return;
              _title = value;
              RaisePropertyChanged(() => Title);
           }
        }
        private ICollection<string> _subtitles;
        public ICollection<string> Subtitles
        {
           get
           {
              if (_subtitles == null)
                 _subtitles = new ObservableCollection<string>();
              return _subtitles;
           }
           set
           {
              if (value == _subtitles)
                 return;
              _subtitles = value;
              RaisePropertyChanged(() => Subtitles);
           }
        }
        public YourTitleClass(string title)
        {
           _title = title;
        }       
    }

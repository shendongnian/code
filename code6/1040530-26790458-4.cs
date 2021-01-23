        public class CustomObject : INotifyPropertyChanged
        {
            private string _someText; private int _aNumber;  private Image _anImage;
            public event PropertyChangedEventHandler PropertyChanged;
            public CustomObject(string sometext, int anumber, Image animage)
            { _someText = sometext; _aNumber = anumber; _anImage = animage; }
            [DisplayName("Some Text")]
            public string SomeText { get { return _someText; }
                set { _someText = value; this.NotifyPropertyChanged("SomeText"); }
            }
            public int ANumber { get { return _aNumber; }
                set { _aNumber = value; this.NotifyPropertyChanged("ANumber"); }
            }
            [DisplayName("My Image")]
            public Image AnImage { get { return _anImage; }
                set { _anImage = value; this.NotifyPropertyChanged("AnImage"); }
            }
            private void NotifyPropertyChanged(string name)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        /// <summary>
        /// This objet contains all useful data
        /// </summary>
        public class InformationValueObject : INotifyPropertyChanged
        {
            private string _text1;
            private string _text2;
            public string Text1
            {
                get { return _text1; }
                set { _text1 = value; OnPropertyChanged("Text1"); }
            }
          
            public string Text2
            {
                get { return _text2; }
                set { _text2 = value; OnPropertyChanged("Text2"); }
            }
            public event PropertyChangedEventHandler PropertyChanged;
            private void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    public class NewClass: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _text;
        public string Text
        {
            get { return _text; }
            set
            {
                if ( _text!= value)
                {
                    _text= value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Text"));
                    }
                }
            }
        } 
    } 

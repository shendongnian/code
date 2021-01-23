    class X : System.ComponentModel.INotifyPropertyChanged
    {
        public event  System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        public IEnumerable<object> Groups //Replace 'object' with the type your are using...
        {
            get{ return m_Groups; }
            set
            {
                m_Groups = value;
                //Raise the event to notify that the property has actually got a new value
                var handler = PropertyChanged;
                if(handler != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Groups"));
            }
        } IEnumerable<object> m_Groups = new List<object>();
    }

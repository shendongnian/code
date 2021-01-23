    using System.Runtime.CompilerServices;
    
    class BetterClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        // Check the attribute in the following line :
        private void FirePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    
        private int sampleIntField;
    
        public int SampleIntProperty
        {
            get { return sampleIntField; }
            set
            {
                if (value != sampleIntField)
                {
                    sampleIntField = value;
                    // no "magic string" in the following line :
                    FirePropertyChanged();
                }
            }
        }
    }

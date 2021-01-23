    public class AClass : INotifyPropertyChanging
    {
        private int aField;
        public int AProperty
        {
            get { return aField; }
            set 
            {
                OnPropertyChanging("AProperty");
                aField = value; 
            }
        }
        
        private void OnPropertyChanging(string propertyName) 
        {
            PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
        }
        public event PropertyChangingEventHandler PropertyChanging = delegate { };
    }

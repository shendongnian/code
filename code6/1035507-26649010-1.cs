    public class MyCodeBehind : INotifyPropertyChanged
    {
        private int _printablePageCount = 0;
    
        public int PrintablePageCount
        {
            get { return _printablePageCount; }
            set 
            { 
                return _printablePageCount = value; 
                OnPropertyChanged("PrintablePageCount");
            }
        }
    
        private void OnCanPrintChanged(object sender, EventArgs arg)
        {
            int t = 0;
            foreach(MyFileInfo f in lst)
            {
                if (f.IsValid && f.IfPrint)
                {
                    t++;
                }
            }
    
            PrintablePageCount = t;
        }
    
        
        private void OnPropertyChanged(string propertyName) 
        {
            if (PropertyChanged != null) 
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class MyFileInfo : INotifyPropertyChanged
    {
        private Boolean ifPrint;
        private Boolean isValid;
        ...
    
        public Boolean IfPrint {
            get{
                return this.ifPrint;
            }
            set{
                if (this.ifPrint != value){
                    this.ifPrint = value;
                    onPropertyChanged("IfPrint");
                    OnCanPrintChanged();
                }
            }
        }
    
        public Boolean IsValid {
            get {
                return this.isValid;
            }
            set {
                if (this.isValid!= value) {
                    this.isValid = value;
                    onPropertyChanged("IsValid");
                    OnCanPrintChanged();
                }
            }
        }
    
        private void onPropertyChanged(string propertyName) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private void OnCanPrintChanged()
        {
            if (CanPrintChanged != null)
            {
                CanPrintChanged(this, EventArgs.Empty);
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CanPrintChanged;
    }

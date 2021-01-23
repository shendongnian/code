    public class Formulate: INotifyPropertyChanged 
    { 
       public Nullable<decimal> H
        {
            get { return this._h; }
            set
            {
                this._h = value;
                NotifyPropertyChanged("H");
                NotifyPropertyChanged("Calculation");
            }
        }
        private Nullable<decimal> _h;
    
    
        public Nullable<decimal> Q
        {
            get { return this._q; }
            set
            {
                this._q = value;
                NotifyPropertyChanged("Q");
                NotifyPropertyChanged("Calculation");
            }
        }
        private Nullable<decimal> _h;
    
    
        public Nullable<decimal> Calculation
        {
            get { return _h == null || _q == null ? null : _h.Value / _q.Value; }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }

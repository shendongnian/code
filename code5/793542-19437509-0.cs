    public class example : INotifyPropertyChanged
    {
        private string _SelectedItem;
    
    
        public string SelectedItem 
        {
            get { return _SelectedItem; }
            set
            {
               _SelectedItem = value;
    
               RaisePropertyChanged("SelectedItem");
             }
        }
        public event PropertyChangedEventHandler PropertyChanged;
         protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new   System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
        public void DoSomething()
        {
             Messagebox.Show("I selected: " + SelectedItem);
        }
    }

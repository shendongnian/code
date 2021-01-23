    public class SelectOne : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        private bool isSelected = false;
        private HashSet<SelectOne> selecteOnes = null;
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                if (isSelected == value) return;
                if (isSelected && selecteOnes != null)
                {
                    foreach (SelectOne so in selecteOnes)
                    {
                        if (so == this) continue;
                        so.IsSelected = false;
                    }
                }
                NotifyPropertyChanged("IsSelected");
            }
        }
        public void SelectOne() { }
        public void SelectOne(bool IsSelected) { isSelected = IsSelected; }
        public void SelectedOne(bool IsSelected, HashSet<SelectOne> SelecteOnes)
        {   
            isSelected = IsSelected;
            selecteOnes = SelecteOnes; 
        } 
    }

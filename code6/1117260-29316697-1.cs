    public class ViewItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            var copy = PropertyChanged;
            if (copy != null) 
                copy(this, new PropertyChangedEventArgs(caller));
        }
    }

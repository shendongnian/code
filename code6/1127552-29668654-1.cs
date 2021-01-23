    public class MainViewModel: INotifyPropertyChanged
    {
        private Human human;
        public Human Human
        {
            get { return human; }
            set
            {
                human = value;
                OnPropertyChange("Human");
            }
        }
        ...
    }

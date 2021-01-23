    public class Activity : INotifyPropertyChanged
    {
        public string Name { get; set; }
        private bool isSelected;
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                if (value != isSelected)
                {
                    value = isSelected;
                    ...
                }
            }
        }

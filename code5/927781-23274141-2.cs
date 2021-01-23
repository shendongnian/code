    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int choice = 0;
        public int Choice
        {
            get { return choice; }
            set
            {
                if (value != choice)
                {
                    choice = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, 
                                        new PropertyChangedEventArgs("Choice"));
                    }
                    Visible = choice == 0;
                }
            }
        }
        private bool visible = true;
        public bool Visible
        {
            get { return visible; }
            set
            {
                if (value != visible)
                {
                    visible = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, 
                                        new PropertyChangedEventArgs("Visible"));
                    }
                }
            }
        }
    }

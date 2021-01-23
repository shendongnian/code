    private bool isChecked;
            public bool IsChecked
            {
                get { return isChecked; }
                set
                {
                    isChecked = value;
                    OnPropertyChanged("IsChecked");
                }
            }

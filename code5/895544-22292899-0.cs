    class Player : INotifyPropertyChanged
        {
            List<Point> _selectedCells = new List<Point>();
            public List<Point> SelectedCells
            {
                get
                {
                    return _selectedCells;
                }
                set
                {
                    if (value != _selectedCells)
                    {
                        _selectedCells = value;
                        RaisePropertyChange(new PropertyChangedEventArgs("SelectedCells"));
                    }
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
            protected void RaisePropertyChange(PropertyChangedEventArgs e)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, e);
                }
            }
        }

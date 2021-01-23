    public ChamberViewModel SelectedChamber
        {
            get { return _selectedChamber; }
            set
            {
                _selectedChamber = value;
                UpdateChart();
            }
        }

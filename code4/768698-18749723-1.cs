    public string SelectedResult
    {
        get { ... }
        set 
        {
            _selectedResult = value;
            OnSelectedResultChanged(); // Go do what you need to do here
        }
     }

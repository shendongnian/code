    private string _Text;
    public string Text
    {
        get { return _Text; }
        set
        {
            Debug.Print(
               "ViewModel.Text (old value=" + (_Text ?? "<null>") +
               ", new value=" + (value ?? "<null>") + ")");
            _Text = value;
        }
    }

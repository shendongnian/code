    private bool _isChecked;
    public bool IsChecked {
      get { return _isChecked; }
      set {
        _isChecked = value;
        Debug.WriteLine(string.Format("Checkbox check state changed to: {0}", _isChecked ? "Checked" : "Not Checked"));
      }
    }

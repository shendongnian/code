    private string _comboValue { get; set; }
    public string ShowAndGetComboValue()
    {
        this.ShowDialog();
        return _comboValue;
    }

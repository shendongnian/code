    public delegate void OnCheckedEventHandler(bool checkState);
    public event OnCheckedEventHandler OnCheckboxChecked;
    public void checkBox1_Checked(object sender, EventArgs e)
    {
        if (OnCheckboxChecked != null)
            OnCheckboxChecked(checkBox1.Checked);
    }

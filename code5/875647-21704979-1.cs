    public void UpdateComboBox(ComboBox cmbBox, Type t)
    {
       foreach(string item in Enum.GetNames(t))
       {
           cmbBox.Items.Add(item);
       }
    }

    public void UpdateComboBox(ComboBox cmbBox, Enum values)
    {
       foreach(string item in Enum.GetNames(values.GetType()))
       {
           cmbBox.Items.Add(item);
       }
    }

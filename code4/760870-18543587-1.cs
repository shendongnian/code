    public void AddTypesToComboBox(ComboBox box)
    {
        for (int i = 0; i < type.Length; i++)
        {
            box.Items.Add(type[i]);
        }
    }

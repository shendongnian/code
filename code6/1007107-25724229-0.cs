    public void PopulateNamelistComboBox()
    {
        _Namelist.Clear();
        _Namelist.Add("Select a Name");
        _Namelist.AddRange((from p in context.Peoples
                          select p.Name).ToList());
        comboBox1.DataSource = _Namelist;
    }

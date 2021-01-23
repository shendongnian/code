    private void Init()
    {
        cmbHersteller.Items.Clear();
        var list = _pricelist.GetHersteller();
        list.Insert(0, "");
        cmbHersteller.ComboBox.DataSource = list;
        cmbHersteller.ComboBox.SelectedIndex = 0;
    }

    private ComboBoxCustomType<Order> _cmbCustom;
    //this method used in constructor of the Form
    private void ComboBoxCustomType_Initialize()
    {
        _cmbCustom = new ComboBoxCustomType<Order>();
        _cmbCustom.Location = new Point(100, 20);
        _cmbCustom.Visible = true;
        _cmbCustom.DropDownStyle = ComboBoxStyle.DropDownList;
        _cmbCustom.Items.Add(new Order(0, " - nothing - "));
        _cmbCustom.Items.Add(new Order(1, "One"));
        _cmbCustom.Items.Add(new Order(2, "Three"));
        _cmbCustom.Items.Add(new Order(3, "Four"));
        _cmbCustom.SelectedIndex = 0;
        this.Controls.Add(_cmbCustom);
    }

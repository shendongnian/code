    gttTextBoxLotnr.Focus();
    this.ActiveControl = gttTextBoxLotnr;
    bool enabled = ((DataTable)gttBindingSourceLosplaatsen.DataSource).Rows.Count > 0;
    buttonEditLosplaats.Enabled = enabled;
    buttonDeleteLosplaats.Enabled = enabled;

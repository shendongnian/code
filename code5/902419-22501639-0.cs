    private String _originalValue;
    public EditRecord(String originalValue)
    {
        _originalValue = originalValue;
    }
    //Then in Load handler
    private void EditRecord_Load(object sender, EventArgs e)
    {
        this.txtEName.Text = _originalValue;
    }
    //In main form
    EditRecord frm = new EditRecord(this.name);
    frm.ShowDialog();

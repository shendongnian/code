    private string sTheValue = null;
    public string TheValue
    {
        get { return this.sTheValue; }
    }
    private void Button_Click(object sender, EventArgs e)
    {
        this.sTheValue = "Hello World !";
        this.DialogResult = DialogResult.OK;
        this.Close();
    }

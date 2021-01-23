    public string Player1 {get; private set;}
    public string Player2 {get; private set;}
    private void btnOK_Click(object sender, EventArgs e)
    {
        this.Player1 = txtBoxForPlayer1.Text;
        this.Player2 = txtBoxForPlayer2.Text;
        this.DialogResult = DialogResult.OK;
    }

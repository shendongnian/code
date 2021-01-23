    private string LastFinalTrans { get; set; }
    private void txtFinalTrans_TextChanged_1(object sender, EventArgs e)
    {
        TextBox txt = (TextBox) sender;
        if(LastFinalTrans == txt.Text)
        {
            // ...
        }
        LastFinalTrans =  txt.Text;
    }

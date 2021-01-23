    protected void btnCheck_Click(object sender, EventArgs e)
    {
        foreach (Control s in Panel1.Controls)
        {
            if (s is TextBox)
            {
                TextBox tb = (TextBox)s;
                choiceList.Add(tb.Text.Trim());
            }                       
        }
    }

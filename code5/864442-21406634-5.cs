    protected void btnCheck_Click(object sender, EventArgs e)
    {
        foreach (TextBox t in Panel1.Controls.OfType <TextBox>())
        {
            choiceList.Add(t.Text.Trim());
        }
    }

    protected void minus_Click(object sender, EventArgs e)
    {
        sign = "-";
        // Store sign in Session
        Session["theSign"] = sign;
        num1 = double.Parse(tb1.Text);
        tb1.Text = "";
    }

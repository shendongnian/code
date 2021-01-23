    protected void btnAdd_Click1(object sender, EventArgs e)
    {
        int a = Convert.ToInt32(txtFirstNumber.Text);
        int b = Convert.ToInt32(txtSecondNumber.Text);
        int c = a + b;
        txtSum.Text = c.ToString();
        txtFirstNumber.Text = "";
        txtSecondNumber.Text = "";
    }

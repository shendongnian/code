    protected void btnOne_Click(object sender, EventArgs e)
    {
        btnTwo.Visible = true;
        btnOne.Visible = false;
    }
    protected void btnTwo_Click(object sender, EventArgs e)
    {
        btnTwo.Visible = false;
        btnOne.Visible = true;
    }

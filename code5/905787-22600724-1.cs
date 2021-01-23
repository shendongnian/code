    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        var textBoxes = new[] { txtFirstName, txtLastName, txtPayRate, txtStartDate, txtEndDate };
        var isValid = true;
        foreach (var textBox in textBoxes)
        {
            if (textBox.Text == "")
            {
                isValid = false;
                textBox.BackColor = System.Drawing.Color.Yellow;
            }
            else
            {
                textBox.BackColor = System.Drawing.Color.White;
            }
        }
        if (!isValid)
            return;
        Session["txtFirstName"] = txtFirstName.Text;
        Session["txtLastName"] = txtLastName.Text;
        Session["txtPayRate"] = txtPayRate.Text;
        Session["txtStartDate"] = txtStartDate.Text;
        Session["txtEndDate"] = txtEndDate.Text;
        Response.Redirect("frmPersonnelVerified.aspx");
    }

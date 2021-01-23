    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //Assigning our form data so session state values
        Session["txtFirstName"] = txtFirstName.Text;
        Session["txtLastName"] = txtLastName.Text;
        Session["txtPayRate"] = txtPayRate.Text;
        Session["txtStartDate"] = txtStartDate.Text;
        Session["txtEndDate"] = txtEndDate.Text;
    
        string errFN;
        string errLN;
        string errPD;
        string errSD;
        string errED;
    
        //Validation of each session state making sure they are not empty 
        //(probably a better way to do this but what I came up with)
        if(txtFirstName.Text.ToString().Trim().Equals(""))
        {
            txtFirstName.BackColor = System.Drawing.Color.Yellow;
            errFN = Convert.ToString("First Name may not be empty.");
        }
        if(txtLastName.Text.ToString().Trim().Equals(""))
        {
            txtLastName.BackColor = System.Drawing.Color.Yellow;
            errLN = Convert.ToString("Last Name may not be empty.");
        }
        if(txtPayRate.Text.ToString().Trim().Equals(""))
        {
            txtPayRate.BackColor = System.Drawing.Color.Yellow;
            errPD = Convert.ToString("Pay Rate may not be empty.");
        }
        if(txtStartDate.Text.ToString().Trim().Equals(""))
        {
            txtStartDate.BackColor = System.Drawing.Color.Yellow;
            errSD = Convert.ToString("Start Date may not be empty.");
        }
        if(txtEndDate.Text.ToString().Trim().Equals(""))
        {
            txtEndDate.BackColor = System.Drawing.Color.Yellow;
            errED = Convert.ToString("End Date may not be empty.");
        }
    
        if (txtFirstName.Text.ToString().Trim().Equals("") ||     txtLastName.Text.ToString().Trim().Equals("") || txtPayRate.Text.ToString().Trim().Equals("") ||
            txtStartDate.Text.ToString().Trim().Equals("") || txtEndDate.Text.ToString().Trim().Equals(""))
        {
            lblError.Text = errFN + errLN + errPD + errSD + errED;
        }
        else
        {
            Response.Redirect("~/frmPersonalVerified.aspx");
        }
    }

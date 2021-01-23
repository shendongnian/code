    protected void dvApplicantDetails_ItemCommand(object sender, DetailsViewCommandEventArgs e)
    {
        if (e.CommandName == "Update")
        {
            string firstName = ((TextBox)dvApplicantDetails.Rows[1].Cells[1].Controls[0]).Text;
            string lastName = ((TextBox)dvApplicantDetails.Rows[2].Cells[1].Controls[0]).Text
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        string sFirstName = GetDVRowValue(dvApplicantDetails, "ApplicantID")
    }
    
    public string GetDVRowValue(DetailsView dv, string sField)
    {
        string sRetVal = string.Empty;
        foreach (DetailsViewRow dvr in dv.Rows)
        {
           if (dvr.Cells[0].Text == sField)
               sRetVal = dvr.Cells[1].Text;
        }
        return sRetVal;
    }

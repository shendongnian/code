    protected void UpdateButton_Click(object sender, EventArgs e)
    {
        TextBox applicantIdTextBox = RadListView8.FindControl("ApplicantIdTextBox") as TextBox;
        FileUpload photoTextBox = RadListView8.FindControl("photoTextBox") as FileUpload;
        if ((applicantIdTextBox != null) && (photoTextBox != null))
        {
            string fileName = Path.GetExtension(applicantIdTextBox.Text + photoTextBox.FileName);
            string fileSavePath = Server.MapPath("ImageStorage/" + fileName);
            tblPersonalInfo personalInfo = new tblPersonalInfo();
            personalInfo.photo = fileName;
            photoTextBox.SaveAs(fileSavePath);
            dbcontext.AddTotblPersonalInfoes(personalInfo);
            dbcontext.SaveChanges();
        }
    }

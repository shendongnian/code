    protected void Button1_Click(object sender, EventArgs e)
    {
    	if (this.FileUpload1.HasFile)
    	{
    		this.FileUpload1.SaveAs(targetFolder + this.FileUpload1.FileName);
    		lblResult.Visible = true;
    		lblResult.Text = string.Format("{0} Successfully Uploaded", this.FileUpload1.FileName);
    	}
    }

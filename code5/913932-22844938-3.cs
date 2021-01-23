    protected void UploadFile(object sender, EventArgs e) {
    	string fileName = Server.HtmlEncode(FileUpload1.PostedFile.FileName);
    	string extension = System.IO.Path.GetExtension(fileName);
    
    	if (extension == ".jpeg") {
    		string fn = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
    		string SaveLocation = Server.MapPath("Data") + "\\" + fn;
    		try {
    			FileUpload1.PostedFile.SaveAs(SaveLocation);
    			Response.Write("The file has been uploaded.");
    		} catch (Exception ex) {
    			Session["uploadLabel"] = "Something";// use session to store label text
    		}
    	} else {
    		Session["uploadLabel"] = "Only jpeg is allow";	// use session to store label text
    	}
    }
    protected void panelUpdate_Click(object sender, EventArgs e) {
    	lblUpload.Text = Session["uploadLabel"].ToString() ?? "";	// session value or empty if session is null
    }

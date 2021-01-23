    protected void UploadFile(object sender, EventArgs e) {
    	string extension = System.IO.Path.GetExtension(FileUpload1.FileName);// SHORTENED
    
    	if (extension == ".jpeg") {
    		string fn = FileUpload1.FileName;	// SHORTENED
    		string SaveLocation = Server.MapPath("Data") + "\\" + fn;
    		try {
    			FileUpload1.SaveAs(SaveLocation);	// SHORTENED
    			Response.Write("The file has been uploaded.");
    		} catch (Exception ex) {
    			Session["uploadLabel"] = "Something";// use session to store label text
    		}
    	} else {
    		Session["uploadLabel"] = "Only jpeg is allow";	// use session to store label text
    	}
    }

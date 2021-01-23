    protected void Asyncfileupload1_UploadedComplete(object sender, AsyncFileUploadEventArgs e)
    {
        string name = Asyncfileupload1.FileName;
        string[] spi = name.Split('.');
        int len = spi.Length;
        string type = spi[len - 1];
        if (type == "apk" || type == "ipa")
        {
            if (Asyncfileupload1.PostedFile.ContentLength > 10)
            {
                string filename = System.IO.Path.GetFileName(Asyncfileupload1.FileName);
                string ext = Path.GetExtension(filename);
                string newfilename = Path.GetRandomFileName();
                newfilename += ext;
                Asyncfileupload1.SaveAs(Server.MapPath("~/product_application/") + newfilename);
                MobileStoreEntities mse = new MobileStoreEntities();
                ProductMast um = new ProductMast();
                int loginid = Utility.login_id();
    
                um = mse.ProductMasts.Where(i => i.ProductID == proid).FirstOrDefault();
                um.ApplicationFile = "~/product_application/" + newfilename;
                int check1 = mse.SaveChanges();
                lblDoc.Text = "Old file is available. Want to change? Then Upload";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "TestAlert", "alert('" + "Size problem." + "');", true);
            }
            //Response.Redirect("ProductFileUpload.aspx?proid="+HttpUtility.UrlEncode(enc));
            //Response.Redirect("ProductFileUpload.aspx");
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "TestAlert", "alert('" + "Must upload doc, docx or pdf file." + "');", true);
        }
    }

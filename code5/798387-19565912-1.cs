        public string FilePath;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
            //General_SettingsBL gb = new General_SettingsBL();
            string fn = Path.GetFileName(fuprivacypolicies.PostedFile.FileName);
            string SaveLocation = Server.MapPath("UploadedCSVFiles") + "\\" + fn;
            FileInfo fi = new FileInfo(SaveLocation);
            fuprivacypolicies.PostedFile.SaveAs(SaveLocation);
            fuprivacypolicies.PostedFile.InputStream.Dispose();
            Session["fuprivacypoliciesPath"] = SaveLocation;
            Label2.Text = "Uploaded file : "+fn;
           // gb.Privacy_Policies = System.IO.Path.GetExtension(fuprivacypolicies.FileName);
           // gb.Privacy_Policies = System.IO.Path.GetExtension(fuprivacypolicies.FileName);
           // gb.Refund_Policies = System.IO.Path.GetExtension(furefundpolicies.FileName);
           // gb.Terms = System.IO.Path.GetExtension(futerms.FileName);
           // gb.Trial_Period = decimal.Parse(txttrailperoid.Text);
           // gb.Insert();
            lblmsg.Visible = true;
            lblmsg.Text = "Records Inserted Successfully";
            Label1.Text = "Uploaded file : " + fn;
            string ff = Path.GetFileName(furefundpolicies.PostedFile.FileName);
            string SaveLocation2 = Server.MapPath("UploadedCSVFiles") + "\\" + ff;
            furefundpolicies.PostedFile.SaveAs(SaveLocation2);
            furefundpolicies.PostedFile.InputStream.Dispose();
            Session["furefundpoliciesPath"] = SaveLocation2;
            Label2.Text = "Uploaded file : " + ff;
            string ft = Path.GetFileName(futerms.PostedFile.FileName);
            string SaveLocation3 = Server.MapPath("UploadedCSVFiles") + "\\" + ft;
            futerms.PostedFile.SaveAs(SaveLocation3);
            futerms.PostedFile.InputStream.Dispose();
            Session["futermsPath"] = SaveLocation3;
            Label3.Text = "Uploaded file : " + ft;
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
        }
        protected void deleterefundpolicies(object sender, EventArgs e)
        {
            //string fn = Path.GetFileName(fuprivacypolicies.PostedFile.FileName);
            //string SaveLocation = Server.MapPath("UploadedCSVFiles") + "\\" + fn;
            //FileInfo fi = new FileInfo(SaveLocation);
            ////furefundpolicies.ID = null;
            //fi.Delete();
            if (Session["furefundpoliciesPath"] != null && File.Exists(Session["furefundpoliciesPath"].ToString()))
            {
                File.Delete(Session["furefundpoliciesPath"].ToString());
                Label1.Text = "File deleted";
            }
        }
        protected void deleteprivacypolicies(object sender, EventArgs e)
        {
            //fuprivacypolicies.ID = null;
            // fuprivacypolicies = new FileUpload();
            if (Session["fuprivacypoliciesPath"]!=null&&File.Exists(Session["fuprivacypoliciesPath"].ToString())) {
                File.Delete(Session["fuprivacypoliciesPath"].ToString());
                Label2.Text = "File deleted";
            }
        }
        protected void deleteterms(object sender, EventArgs e)
        {
            //futerms.ID = null;
            // futerms = new FileUpload();
            if (Session["futermsPath"]!=null&&File.Exists(Session["futermsPath"].ToString()))
            {
                File.Delete(Session["futermsPath"].ToString());
                Label3.Text = "File deleted";
            }
        }

    using System;
    using System.IO;
    using System.Web;
    
    namespace upload
    {
        public partial class Upload : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
             if (IsPostBack)
             {
                 UploadFile(sender,e);
             }
            }
            protected void UploadFile(object sender, EventArgs e)
            {
                HttpFileCollection fileCollection = Request.Files;
                for (int i = 0; i < fileCollection.Count; i++)
                {
                    HttpPostedFile upload = fileCollection[i];
                    string filename ="c:\\Test\\" +  Path.GetRandomFileName();
                    upload.SaveAs(filename);
                }
            }
        }
    
    }

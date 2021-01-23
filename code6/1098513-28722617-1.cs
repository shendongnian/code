    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Drawing;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data.SqlTypes;
    using System.Data.SqlClient;
    using System.Web.Configuration;
    using System.IO;
    using System.Data;
    public partial class Test : System.Web.UI.Page
    {
        private string fontUploadDirectory;
        protected void Page_Load(object sender, EventArgs e)
        {
            // ensure files are uploaded to the right folder
            fontUploadDirectory = Server.MapPath(@"~\fonts\");
        }
        protected void btnUploadFont_Click(object sender, EventArgs e)
        {
            string[] validFileTypes = { ".eot", ".ttf", ".svg", ".woff", ".woff2", ".css" };
            // check files are being submitted
            if (flupFonts.HasFiles == false)
            {
                lblUpload.Text = "No files have been selected.";
            }
            else
            {
                HttpFileCollection fileCollection = Request.Files;
                foreach (HttpPostedFile uploadedFont in flupFonts.PostedFiles)
                {
                    string ext = System.IO.Path.GetExtension(uploadedFont.FileName);
                    if (isValid(uploadedFont, validFileTypes, ext))
                    {
                        uploadedFont.SaveAs(fontUploadDirectory + "\\" + System.IO.Path.GetFileName(uploadedFont.FileName));
                    }
                }
            }
        }
        private bool isValid(HttpPostedFile file, string[] extAry, string ext)
        {
            bool isValid = false;
            for (int i = 0; i < extAry.Length; i++)
            {
                if (ext.ToLowerInvariant().IndexOf(extAry[i]) > -1)
                    isValid = true;
            }
            return isValid;
        }
    }

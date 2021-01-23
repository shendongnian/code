    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
     
    public partial class AjaxUploadFile : System.Web.UI.Page
    {
     
        protected void FileUploadComplete(object sender, EventArgs e)
        {
     
            string savePath = @"F:\BLOG\Projects\InsertData\UploadedFiles\";
            string filename = AsyncFileUpload1.FileName;
     
            if (AsyncFileUpload1.HasFile)
            {
                savePath += filename;
                AsyncFileUpload1.SaveAs(savePath);
     
            }
     
        }
    }

    using System;
    
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile == true)
            {
                var ChNumber = txtNumber.Text;
    
                string img = this.FileUpload1.PostedFile.FileName;
                //Save image to database function
            }
            else
            {
                lblStatus.Text = "Image not Uploaded";
            }
        }
    }
       

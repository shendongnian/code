    using System.Web.UI;
    using AjaxControlToolkit;
     
    namespace WebApplication1
    {
        public partial class ImageUpload : System.Web.UI.Page
        {
     
            protected void MyHtmlEditorExtender_ImageUploadComplete(object sender, AjaxFileUploadEventArgs e)
            {
                // Generate file path
                string filePath = "~/Images/" + e.FileName;
     
                // Save uploaded file to the file system
                var ajaxFileUpload = (AjaxFileUpload)sender;
                ajaxFileUpload.SaveAs(MapPath(filePath));
     
                // Update client with saved image path
                e.PostedUrl = Page.ResolveUrl(filePath);
            }
        }
    }

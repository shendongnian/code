     Attachment = new AttachmentContract
            {
                Path = AppSettings.NoticeAttachmentFilePath,
                FileName = "filenamehtml",
                Content = testmethod()
            }
     private string TestMethod(ModelData modelData)
        {
            ViewData.Model = modelData;
            StringWriter output;
            using (output = new StringWriter())
            {
                var result = ViewEngines.Engines.FindView(this.ControllerContext, "EmailAttachment", null);
                var viewContext = new ViewContext(this.ControllerContext, result.View, this.ViewData, this.ControllerContext.Controller.TempData, output);
                result.View.Render(viewContext, output);
                result.ViewEngine.ReleaseView(this.ControllerContext, result.View);
            }
            return output.ToString();
        }
    Where EmailAttachment is a view i am going to fill in my logic using the same model

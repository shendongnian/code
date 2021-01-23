        public void ProcessRequest(HttpContext context)
        {
            var fileName = context.Request.Params["fileName"];
            if (String.IsNullOrEmpty(fileName)) RenderInvalidRequestMessage(context);
            if (fileName.Contains("..")) RenderInvalidRequestMessage(context);
            if (fileName.Contains("/")) RenderInvalidRequestMessage(context);
            if (fileName.Contains("\\")) RenderInvalidRequestMessage(context);
            var fullFilePath = "D:\\Images\\" + fileName;
            if (!File.Exists(fullFilePath)) RenderInvalidRequestMessage(context);
            
            //TODO: Add validation and any security check.
            context.Response.ContentType = "image/png";
            
            context.Response.WriteFile(fullFilePath);
        }
        private void RenderInvalidRequestMessage(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("File not found.");
            context.Response.End();
        }

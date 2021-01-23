        public void ProcessRequest(HttpContext context)
        {
            var root = "D:\\Images";
            var fileName = context.Request.Params["fileName"];
            if (String.IsNullOrEmpty(fileName)) RenderInvalidRequestMessage(context);
            var fullFilePath = root + "\\" + fileName;
            //var dir = (new FileInfo(fullFilePath)).Directory;
            //if (dir == null || dir.FullName != root) RenderInvalidRequestMessage(context);
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

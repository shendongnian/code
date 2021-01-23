     public void ProcessRequest(HttpContext context)
        {
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;
            string action = request["Action"];
            switch (action)
            {
                case "New":
                    string result = "failed";
                    try
                    {
                        string fileName = SaveCaper(context);
                        result = "successed";
                        response.Write("{\"result\":" + result.ToString().ToLower() + "}");
                    }
                    catch
                    {
                        response.Write("{\"result\":" + result.ToString().ToLower() + "}");
                    }
                    break;
                default:
                    throw new Exception("Invalid sort column name!.");
            }
        }
        private string SaveCaper(HttpContext context)
        {
            string fileName = string.Empty;
            string path = context.Server.MapPath("~/NewImages");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            try
            {
                var file = context.Request.Files[0];
                if (HttpContext.Current.Request.Browser.Browser.ToUpper() == "IE")
                {
                    string[] files = file.FileName.Split(new char[] { '\\' });
                    fileName = files[files.Length - 1];
                }
                else
                {
                    fileName = file.FileName;
                }
                string strFileName = fileName;
                fileName = Path.Combine(path, fileName);
                try
                {
                    file.SaveAs(fileName);
                }
                catch (Exception exp)
                {
                    //log the exception
                }
            }
            catch (Exception exp)
            {
                //log the exception
            }
            return fileName;
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

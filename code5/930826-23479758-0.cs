    public HttpResponseMessage Upload()
        {
            HttpResponseMessage m = new HttpResponseMessage(HttpStatusCode.OK);
            List<string> returnlist = new List<string>();
            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase file = Request.Files[i]; //Uploaded file
                //Use the following properties to get file's name, size and MIMEType
                int fileSize = file.ContentLength;
                if (file.FileName != "")
                {
                    string fileName = string.Format("{0}.{1}", Guid.NewGuid().ToString(), file.FileName.ToString().Split('.')[1].ToString());
                    returnlist.Add(fileName);
                }
            }
    //Here I write the response message headers
            HttpResponseMessage response = new HttpResponseMessage();
            response.Content = new StringContent(string.Join(",", returnlist), Encoding.UTF8, "text/html");
            
            response.Headers.Add("data", string.Join(",", returnlist));
            return response;
        }

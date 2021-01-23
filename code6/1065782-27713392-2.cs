        public static void configureMultiPartFormDataRequest(HttpWebRequest request, string xmlBody, string contentType, DocumentList documents)
        {
            string boundaryName = string.Empty;
            boundaryName = "00000000-0000-0000-0000-000000000000";
            request.ContentType = string.Format("multipart/form-data; boundary={0}", boundaryName); 
            bool multipleDocs = documents.Count > 1;
            // start building the multipart request body
            string requestBodyStart = "\r\n\r\n--" + boundaryName + "\r\n" + "Content-Type: application/xml\r\n" +
                    "Content-Disposition: form-data\r\n\r\n" +
                    xmlBody;
            string requestBodyEnd = "\r\n--" + boundaryName + "--\r\n\r\n";
            byte[] bodyStart = System.Text.Encoding.UTF8.GetBytes(requestBodyStart.ToString());
            byte[] bodyEnd = System.Text.Encoding.UTF8.GetBytes(requestBodyEnd.ToString());
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(bodyStart, 0, requestBodyStart.ToString().Length);
            // Do documents
            addRequestDocs(dataStream, contentType, documents, boundaryName);
            // Write Stream end
            dataStream.Write(bodyEnd, 0, requestBodyEnd.ToString().Length);
            dataStream.Close();
        }
        public static void addRequestDocs(Stream dataStream, string contentType, DocumentList documents, string boundaryName)
        {
            int counter = 0;
            foreach (Document x in documents)
            {
                counter = counter + 1;
                string docBodyStart = string.Empty;
                string myDocName = GetPhysicalFileName(x.FileName);
                string requestDocumentBodyStart = "\r\n--" + boundaryName + "\r\n" + "Content-Type: " + contentType + "\r\n" +
                    "Content-Disposition: file; filename=\"" + x.FileName + "\"; documentId=" + counter + "\r\n\r\n";
                byte[] bodyStart = System.Text.Encoding.UTF8.GetBytes(requestDocumentBodyStart.ToString());
                dataStream.Write(bodyStart, 0, requestDocumentBodyStart.ToString().Length);
                byte[] docContents = File.ReadAllBytes(myDocName);
                // read contents of provided document(s) into the stream
                dataStream.Write(docContents, 0, docContents.Length);
            }
        }
        public static string GetPhysicalFileName(string relativeFileName)
        {
            string virtualFileName = string.Format("{0}\\{1}", HttpRuntime.AppDomainAppVirtualPath, relativeFileName);
            string physicalFileName = HttpContext.Current.Request.MapPath(virtualFileName);
            return physicalFileName;
        }

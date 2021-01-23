    [HttpPost]
    [ActionName("ZipFileAction")]
    public HttpResponseMessage ZipFiles([FromBody]int[] id)
    {
        if (id == null)
        {//Required IDs were not provided
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));
        }
        List<Document> documents = new List<Document>();
        using (var context = new ApplicationDbContext())
        {
            foreach (int NextDocument in id)
            {
                Document document = context.Documents.Find(NextDocument);
                if (document == null)
                {
                    throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
                }
                documents.Add(document);
            }
            using (var zipFile = new ZipFile())
            {
                // Make zip file
                foreach (var d in documents)
                {
                    var dt = d.DocumentDate.ToString("y").Replace('/', '-').Replace(':', '-');
                    string fileName = String.Format("{0}-{1}-{2}.pdf", dt, d.PipeName, d.LocationAb);
                    zipFile.AddEntry(fileName, d.DocumentUrl);
                }
                return ZipContentResult(zipFile);
            }
        }
    }

    public HttpResponseMessage Get([FromUri] int[] ids)
    {
        using (var context = new ApplicationDbContext())
        {
            var documents = context.Documents.Where(doc => ids.Contains(doc.Id)).ToList();
            if (documents.Count != ids.Length)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
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

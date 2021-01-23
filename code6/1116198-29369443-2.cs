    public HttpResponseMessage Get(string[] id)
    {
        List<Document> documents = new List<Document>();
        using (var context = new ApplicationDbContext())
        {
            foreach (string NextDocument in id)
            {
                Document document = context.Documents.Find(new string[]{NextDocument});
                if (document == null)
                {
                    throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
                }
                documents.Add(document);
            }

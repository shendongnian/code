    public Models.SearchResult.Document[] GetDocumentsArray(IEnumerable<Models.SearchResult.Document> docs)
    {
         return docs.Select(a => new Models.SearchResult.Document
                        {
                            CategoryId = a.Document.DocumentCategoryId,
                            TypeId = a.Document.DocumentTypeId,
                            CreateDate = a.CreateDate,
                            Name = (a.Document.DocumentName == null ? a.Document.DocumentPath : a.Document.DocumentName)
    
                        }).OrderBy(a=>a.Name).ToArray();
    }

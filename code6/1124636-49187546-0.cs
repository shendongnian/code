    this.client = new DocumentClient(new Uri(m_ConnInfo.EndPointURL), m_ConnInfo.AccountKey);
    Uri _docDbUri = new Uri("https://8878d4ed-0ee0-4-321-c9ef.documents.azure.com");
    using (var client = new DocumentClient(_docDbUri, m_ConnInfo.AccountKey))
    {
          try
          {
              var coll = client.CreateDocumentCollectionQuery(db.CollectionsLink).ToList().First();
              var docs = client.CreateDocumentQuery(coll.DocumentsLink);
              foreach (var doc in docs)
              {                       
                   if (doc.Id == "123")
                   {
                       client.DeleteDocumentAsync(doc.SelfLink).Wait();
                   }      
              }
          }
          catch (Exception)
          {
               //ignored
          }
    }

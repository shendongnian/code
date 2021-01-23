    public void DuplicateTransports(IEnumerable<int> ids)
    {
        using (var context = new MyContext())
        {
            var transportsToDuplicate = context.Transports
                                               .Include(c => c.Documents.Select(d => d.File)) // load entire aggregate record in a single query
                                               .Where(t => ids.Contains(t.Id));
            foreach (var transport in transportsToDuplicate)
            {
                var documents = transport.Documents
                                         .Where(d => d.Type != Document.DocumentType.Mail)
                                         .Select(d => new Document
                                         {
                                             Type = d.Type,
                                             File = new File
                                             {
                                                 Filename = d.File.Filename,
                                                 FileStream = d.File.FileStream,
                                             }
                                         });
    
                var newTransport = new Transport { TransportNumber = transport.TransportNumber };
                newTransport.Documents.AddRange(documents);
                context.Transports.Add(newTransport);
            }
            context.SaveChanges();
        }
    }

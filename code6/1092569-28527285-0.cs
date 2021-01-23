    t.Documents.Where(doc => doc.Type == EnumDocumentType.Mail).ForEach(doc =>
                {
                    ObjectContext.LoadProperty(doc, x => x.File);
                    Context.Documents.Add(doc);
                    Context.Files.Add(doc.File);
                });

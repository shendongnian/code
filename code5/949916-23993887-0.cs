    public class BatchRepository
    {
        protected override void Update(Batch item)
        {
            using (var dbCtx = new MyDbContext(DBContextName))
            {
                var existingBatch = dbCtx.Batches.Find(item.Key);
                if (null != existingBatch)
                {
                    // Load the documents for the existing batch
                    dbCtx.Entry(existingBatch).Collection(b => b.Documents).Load();
    
                    // Get the list of the documents that were removed from the existing batch
                    var removedDocuments = existingBatch.Documents.Except(item.Documents).ToList();
                    foreach (var doc in removedDocuments)
                    {
                        // Remove the relationship between the documents and the batch
                        existingBatch.Documents.Remove(doc);
                    }
    
                    // Get the list of the newly added documents
                    var addedDocuments = item.Documents.Except(existingBatch.Documents).ToList();
                    foreach (var doc in addedDocuments)
                    {
                        // The document exists in the repository, so we just attach it to the context
                        dbCtx.Documents.Attach(doc);
    
                        // Create the relation between the batch and document
                        existingBatch.Documents.Add(doc);
                    }
    
                    // Overwrite all property current values from modified batch' entity values, 
                    // so that it will have all modified values and mark entity as modified.
                    var batchEntry = dbCtx.Entry(existingBatch);
                    batchEntry.CurrentValues.SetValues(item);
    
                    dbCtx.SaveChanges();
                }
            }
        }
    }

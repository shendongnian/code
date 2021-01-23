    using Microsoft.Azure.Documents;
    using Microsoft.Azure.Documents.Client;
    using Microsoft.Azure.Documents.Linq;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Util
    {
        class Program
        {
            private Uri _docDbUri = new Uri("https://<nameofyourdocdb>.documents.azure.com:443/");
            private string _docDbKey = "<your primary key>";
    
            private async Task DeleteDocsAsync()
            {
                using (var client = new DocumentClient(_docDbUri, _docDbKey))
                {
                    try
                    {
                        var db = client.CreateDatabaseQuery().ToList().First();
                        var coll = client.CreateDocumentCollectionQuery(db.CollectionsLink).ToList().First();
                        var docs = client.CreateDocumentQuery(coll.DocumentsLink);
                        foreach (var doc in docs)
                        {
                            await client.DeleteDocumentAsync(doc.SelfLink);
                        }
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine(ex);
                        throw;
                    }
                }
            }
    
    
    
            static void Main(string[] args)
            {
                try
                {
                    Program p = new Program();
                    p.DeleteDocsAsync().Wait();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }

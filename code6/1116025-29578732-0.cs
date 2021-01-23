        public async Task SaveToDocDb(dynamic jsonDocToSave)
        {
            
            using (var client = new DocumentClient(endpoint, authKey))
            {
                var queryDone = false;
                while (!queryDone)
                {
                    try
                    {
                        await client.CreateDocumentAsync(docCollectionlink, jsonDocToSave);
                        queryDone = true; 
                    }
                    catch (DocumentClientException documentClientException)
                    {
                        var statusCode = (int)documentClientException.StatusCode;
                        if (statusCode == 429 || statusCode == 503)   
                            Thread.Sleep(documentClientException.RetryAfter);
                        else
                            throw;
                    }
                    catch (AggregateException aggregateException)
                    {
                        if(aggregateException.InnerException.GetType() == typeof(DocumentClientException)){
                            var docExcep = aggregateException.InnerException as DocumentClientException;
                            var statusCode = (int)docExcep.StatusCode;
                            if (statusCode == 429 || statusCode == 503)
                                Thread.Sleep(docExcep.RetryAfter);
                            else
                                throw;
                        }
                    }
                }
            }
        }

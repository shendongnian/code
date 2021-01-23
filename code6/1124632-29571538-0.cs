    class CrawlResult
    {
        [JsonProperty("jobId")]
        public string JobId;
    }
    private async Task QueryAndDelete(DocumentClient client, string collectionLink)
    {
        await client.CreateDocumentAsync(collectionLink, new CrawlResult { JobId = "J123" });
        await client.CreateDocumentAsync(collectionLink, new CrawlResult { JobId = "J456" });
        foreach (Document document in client.CreateDocumentQuery(
            collectionLink,
            new SqlQuerySpec(
                "SELECT * FROM crawlResults r WHERE r.jobId = @jobId",
                new SqlParameterCollection(new[] { new SqlParameter { Name = "@jobId", Value = "J123" } })
                )))
        {
            // Optionally, cast to CrawlResult using a dynamic cast
            CrawlResult result = (CrawlResult)(dynamic)document;
            await client.DeleteDocumentAsync(document.SelfLink);
        }
    }

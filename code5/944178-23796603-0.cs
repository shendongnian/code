  
        // Create partial document with a dynamic
        var updateDoc = new System.Dynamic.ExpandoObject();
        updateDoc.Title = "My new title";
        var response = client.Update<ElasticsearchDocument, object>(u => u
            .Index("movies")
            .Id(doc.Id)
            .Document(updateDoc)
         );

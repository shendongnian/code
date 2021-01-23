    while (true)
    {
        // Build fetchXml string with the placeholders.
        string xml = CreateXml(fetchXml, pagingCookie, pageNumber, fetchCount);
    
        // Execute the fetch query and get the xml result.
        RetrieveMultipleRequest fetchRequest1 = new RetrieveMultipleRequest
        {
            Query = new FetchExpression(xml)
        };
    
        EntityCollection returnCollection = ((RetrieveMultipleResponse)_service.Execute(fetchRequest1)).EntityCollection;
        // Check for morerecords, if it returns 1.
        if (returnCollection.MoreRecords)
        {
            // Increment the page number to retrieve the next page.
            pageNumber++;
        }
        else
        {
            // If no more records in the result nodes, exit the loop.
             break;
        }
    }

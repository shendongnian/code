    //...
    StringBuilder query = new StringBuilder();
    query.AppendLine("SELECT TicketID, Name, Company, Product");
    query.AppendLine("FROM YourTable WHERE 1=1");
    if (txtSearch.TextLength > 0)
    {
        query.AppendLine("AND TicketID = @TicketID");
        //Here add sqlparameter with textbox value
    }
    //... and so on
            
        

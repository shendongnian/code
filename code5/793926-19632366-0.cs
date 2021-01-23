    /// PUT api/<controller>/5
    /// <summary>
    /// Upserts a InvoiceLine object and its DocumentHeader to the underlying DataContext
    /// </summary>
    /// <param name="id">Id of the InvoiceLine object.</param>
    /// <param name="value">The InvoiceLine object to upsert.</param>
    /// <returns>An HttpResponseMessage with HttpStatusCode.Ok if everything worked correctly. An exception otherwise.</returns>
    public override HttpResponseMessage Put(string id, [FromBody]InvoiceLine value)
    {
        //If creation date is in UTC format we must change it to local time
        value.DateCreated = value.DateCreated.ToLocalTime();
        //update the document header if there is any change
        var header = Database.Set<DocumentHeader>()
            .FirstOrDefault(x => x.Id == value.Header.Id);
        if (header != null)
        {
            value.Header.DocumentLines = header.DocumentLines;
            value.Header.DocumentNumber = header.DocumentNumber;
            Database.Entry<DocumentHeader>(header)
                .CurrentValues.SetValues(value.Header);
        }
        else
        {
            Database.Set<DocumentHeader>().Add(value.Header);
        }
        // If entity exists, set current values to atomic properties
        // Otherwise, insert as new
        var entity = Database.Set<InvoiceLine>()
            .FirstOrDefault(x => x.Id == id);
        if (entity != null)
        {
            Database.Entry<InvoiceLine>(entity)
                .CurrentValues.SetValues(value);
            FixNavigationProperties(ref entity, value);
        }
        else
        {
            FixNavigationProperties(ref value);
            Database.Set<InvoiceLine>().Add(value);
        }
        if (value is ISynchronizable)
            (value as ISynchronizable).LastUpdated = DateTime.UtcNow;
        // Save changes and handle errors
        SaveChanges();
        return new HttpResponseMessage(HttpStatusCode.OK);
    }

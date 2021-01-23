    public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Customer> delta)
    {
        var nonEditable = delta.NonEditableChanges();
        if (nonEditable.Count > 0)
        {
            throw new HttpException(409, "Cannot update as non-editable fields included");
        }
        // TODO: Your patching action here
    }

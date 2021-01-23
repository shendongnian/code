    bool doesItExistAlready = (from caa in db.ClientAccountAccesses
                               where css.id == guidCode
                               select caa).Any();
    if (doesItExistAlready)
    {
        // Delete old record
        db.DeleteObject(PUTIDENTIFIERHERE);
    }
    // Add new record
    ClientAccountAccess client = new ClientAccountAccess();
    client.GUID = guidCode;
    db.AddToClientAccountAccesses(client);

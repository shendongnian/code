    for (var email in db.v2EmailQueues.OrderBy(c => c.ID).Take(Settings.EMAILS_PER_BATCH))
    {
        // whatever your amazon code was...
        if (sent)
        {
            db.v2EmailQueues.Remove(email);
        }
        else
        {
            email.FailCount++;
        }
    }
    // this will update the database, and its internal cache.
    db.SaveChanges(); 

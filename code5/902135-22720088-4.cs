    var success = true;
    // Start processing all the master records.
    Master master;
    while (null != (master = await StoredProcedures.ClaimRecordsAsync(...)))
    {
        await masterTransform.SendAsync(master);
    }
    // Finished sending master records
    masterTransform.Complete();
    // Now, wait for all the batches to complete.
    await batchAction.Completion;
    return success;

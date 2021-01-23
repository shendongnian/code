    using (var scope = new TransactionScope(TransactionScopeOption.Required, option))
        {
            try
            {
                Context.SaveEmail(_emailInfoList);
                context.SaveSyncState(syncState);
                scope.Complete();
                return true;
            }
            catch (TransactionInDoubtException ex)
            {
                //check whether any one record from the batch has been partially committed . If committed then no need to reprocess this batch.     
    
                // transaction scope should be disposed first .
    
                scope.Dispose();
    
                if (IsReprocessingNeeded(syncState))
                    throw;
    
                return true;
            }
        }
    
            /// <returns></returns>
            private bool IsReprocessingNeeded(SyncStateDataModal syncState)
            {
                while (true)
                {
                    try
                    {
                        var id = _emailInfoList[0].ID;
                        bool isEmailsCommitted = Context.GetJournalEmail().FirstOrDefault(a => a.ID == id) != null;
                        if (!isEmailsCommitted)
                            return true;
                        if (context.EmailSynch(syncState.Id) == null)
                        {
                            context.SaveSyncState(syncState);
                        }
                        return false;
                    }
                    catch (Exception ex)
                    {
    
                        Thread.Sleep(TimeSpan.FromMinutes(AppConfiguration.RetryConnectionIntervalInMin));
                    }
                }
            }

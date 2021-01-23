    protected virtual bool ReadSize()
    {
        if (!initialized)
        {
            if (cachedSize != -1 && !HasQueuedOperations)
            {
                return true;
            }
            else
            {
                ThrowLazyInitializationExceptionIfNotConnected();
                // the below line it has to be.
                CollectionEntry entry = session.PersistenceContext.GetCollectionEntry(this); 
                ICollectionPersister persister = entry.LoadedPersister;
                if (persister.IsExtraLazy)
                {
                    if (HasQueuedOperations)
                    {
                        session.Flush();
                    }
                    cachedSize = persister.GetSize(entry.LoadedKey, session);
                    return true;
                }
            }
        }
        Read();
        return false;
    }

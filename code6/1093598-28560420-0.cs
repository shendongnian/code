        public void Dispose()
        {
            if (Interlocked.Exchange(ref this._disposed, 1) == 0)
            {
                this._expires.EnableExpirationTimer(false);
                ArrayList list = new ArrayList(this._entries.Count);
                lock (this._entriesLock)
                {
                    foreach (DictionaryEntry entry in this._entries)
                    {
                        MemoryCacheEntry entry2 = entry.Value as MemoryCacheEntry;
                        list.Add(entry2);
                    }
                    foreach (MemoryCacheEntry entry3 in list)
                    {
                        MemoryCacheKey key = entry3;
                        entry3.State = EntryState.RemovingFromCache;
                        this._entries.Remove(key);
                    }
                }
                foreach (MemoryCacheEntry entry4 in list)
                {
                    this.RemoveFromCache(entry4, CacheEntryRemovedReason.CacheSpecificEviction, false);
                }
                this._insertBlock.Close();
            }
        }

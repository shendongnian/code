        public IEnumerable<ProcessQueueItem> Generate(Guid batchId)
        {
            var accounts = this.AccountStatusRepository.GetAccountsByBatchId(batchId.ToString());
            
            foreach (var accountStatuse in accounts)
            {
                yield return accountStatuse.AsProcessQueueItem(batchId);
            }
        }

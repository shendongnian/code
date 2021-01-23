    public async IAsyncEnumerable<T> GetConsumingEnumerable()
    {
        lock (_queue) _consumersCount++;
        while (true)
        {
            lock (_queue)
            {
                if (_queue.Count == 0 && _isAddingCompleted) break;
            }
            await _semaphore.WaitAsync();
            bool hasItem;
            T item = default;
            lock (_queue)
            {
                hasItem = _queue.Count > 0;
                if (hasItem) item = _queue.Dequeue();
            }
            if (hasItem) yield return item;
        }
    }

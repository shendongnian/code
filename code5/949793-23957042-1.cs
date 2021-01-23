    internal class AsyncDocumentEnumerable : IAsyncEnumerable<Document>
    {
        private readonly YourQueryType _query;
        public AsyncDocumentEnumerable(YourQueryType query)
        {
            _query = query;
        }
    
        IAsyncEnumerator<Document> GetEnumerator()
        {
            return new AsyncDocumentEnumerator(_query);
        }
    }
    
    
    internal class AsyncDocumentEnumerator : IAsyncDocumentEnumerator<Document>
    {
        private readonly YourQueryType _query;
        private IAsyncEnumerator<DocumentSession> _iter;
    
        public AsyncDocumentEnumerator(YourQueryType query)
        {
            _query = query;
        }
    
        public Task<bool> async MoveNextAsync()
        {
            if(_iter == null)
                _iter = await AsyncDocumentSession.Advanced.StreamAsync(query);
    
            bool moved = await _iter.MoveNextAsync();
               
            if(moved)
                Current = _iter.Current.Document;
            return moved;
        }
        
        public Document Current{get; private set;}
    }

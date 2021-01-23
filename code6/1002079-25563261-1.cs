    class Foo {
        // Only allow this to be set ONCE after the constructor, BY CONTRACT
        private string _query;
        // No setter, can't assign "accidently"
        string Query {
            get {
                if (_query == null) throw new InvalidOperationException("Query not set");
                return _query;
            }
            // Or maybe just:
            // get { return _query; }
        }
        // Call later on, BEFORE Query is used - but ONLY call once
        void BindQuery (string query) {
            if (query == null) throw new ArgumentNullException("query");
            if (_query != null) throw new InvalidOperationException("Query already set");
            _query = query;
        }
    }

    class Foo {
        // Only allow this to be set /once/ after the constructor, /by contract/
        private string _query;
        // No setter, can't assign "accidently"
        string Query {
            get {
                if (_query == null) throw new InvalidOperationException("query not set");
                return _query;
            }
            // Or maybe just:
            // get { return _query; }
        }
        // Call later on, but ONLY call once
        void BindQuery (string query) {
            if (query == null) throw new InvalidArgumentException("query");
            if (_query != null) throw new InvalidOperationException("query already set");
            _query = query;
        }
    }

    object _superLock = new object();
    Dictionary<string, object> _locks = new Dictionary<string, object>();
    string Produce(string key) {
        lock(GetLock(key)) {
            // do stuff
        }
    }
    object GetLock(string key) {
        lock(_superLock) {
            if (!_locks.ContainsKey(key)) {
                _locks[key] = new object();
            }
        }
        return _locks[key];
    }

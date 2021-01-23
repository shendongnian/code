        public class DataManipulator : IManipulator
        {
            protected IDataStorage _storage { get; private set; }
            protected StringDictionary _data { get; private set; }
            public DataManipulator(IDataStorage storage)
            {
                _storage = storage;
                _data = new StringDictionary();
            }
            public void addData(string name, string data)
            {
                this._data.Add(name, data);
            }
            public void saveAllData()
            {                
                // potential implementation - I want to test this
                foreach (DictionaryEntry entry in this._data)
                {
                    this.saveEntry(entry.Key.ToString(), entry.Value.ToString());
                }
            }
            public void saveEntry(string entryKey, string entryValue)
            {
                _storage.Store(entryKey, entryValue);
            }
        }

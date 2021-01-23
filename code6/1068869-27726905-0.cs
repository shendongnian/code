    class MyMap {
        internal IDictionary<string,string> dict = ...
        public ItemGetterResult TryGetValues {
            get {
                return new ItemGetterResult(this);
            }
        }
    }
    
    class ItemGetterResult {
        private readonly MyMap map;
        internal ItemGetterResult(MyMap theMap) {
            map = theMap;
        }
        private bool IsSuccessful {get;set;}
        public static implicit operator bool(ItemGetterResult r) {
            return r.IsSuccessful;
        }
        public ItemGetterResult Get(string key, out string val) {
            var res = new ItemGetterResult();
            res.IsSuccessful = map.dict.TryGetValue(key, out val);
            return res;
        }
    }

    class MyMap {
        internal IDictionary<string,string> dict = ...
        public ItemGetterResult TryGetValues {
            get {
                return new ItemGetterResult(this, true);
            }
        }
    }
    
    class ItemGetterResult {
        private readonly MyMap map;
        private bool IsSuccessful {get;set;}
        internal ItemGetterResult(MyMap theMap, bool successFlag) {
            map = theMap;
            IsSuccessful = successFlag;
        }
        public static implicit operator bool(ItemGetterResult r) {
            return r.IsSuccessful;
        }
        public ItemGetterResult Get(string key, out string val) {
            return new ItemGetterResult(
                map
            ,   this.IsSuccessful && map.dict.TryGetValue(key, out val)
            );
        }
    }

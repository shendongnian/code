    public static class Helper {
        // ... an overload of the TapInto method is about to appear right here
        public static IDictionary<string, object> TapInto(params Expression<Func<object>>[] parameterTouchers) {
            var result = new Dictionary<string, object>();
            foreach (var toucher in parameterTouchers) {
                string name;
                object value;
                toucher.TapInto(out name, out value);
                result[name] = value;
            }
            return result;
        }

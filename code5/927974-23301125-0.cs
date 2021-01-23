    using System.Collections.ObjectModel;
    
    namespace MyNamespace{
        public class BindableValuePairList<TK,TV> : 
            ObservableCollection<ValuePair<TK,TV>> { }
        public class ValuePair<TK,TV> {
            public ValuePair (TK key, TV value) {
                Key = key;
                Value= value;
            }
     
            public TK Key { get; set; }
    
            public TV Value { get; set; }
        }
    }

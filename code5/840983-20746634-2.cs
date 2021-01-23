    public class DynamicDataEntry : DataEntry, IDynamicMetaObjectProvider
        private readonly DynamicDataEntryImpl _inner;
        public DynamicDataEntry() {
            _inner = new DynamicDataEntryImpl(this);
        }
    
        // delegate to inner
        public virtual IEnumerable<string> GetDynamicMemberNames()
        {
            return _inner.GetDynamicMemberNames();
        }
     
        public virtual DynamicMetaObject GetMetaObject(Expression parameter)
        {
            return _inner.GetMetaObject(parameter);
        }
    
        // etc...
    
        // delegated class
        internal class DynamicDataEntryImpl : DynamicObject {
            private readonly DataEntry _outer;
        
            private DyanmicDataEntryImpl(DataEntry outer) {
                 _outer = outer;
            }
    
            // ...
        }
    }

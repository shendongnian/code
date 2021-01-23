    public class DynamicIEnumerable<T> : DynamicObject, IEnumerable<T>
        {
            public IEnumerable<T> _enumerable;
    
            public DynamicIEnumerable(IEnumerable<T> enumerable)
            {
                this._enumerable = enumerable;
            }
    
            public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
            {
                result = new DynamicIEnumerable<T>(_enumerable.Select(x => (T)typeof(T).InvokeMember(binder.Name, BindingFlags.InvokeMethod, null, x, null)));
                return true;
            }
    
            public IEnumerator<T> GetEnumerator()
            {
                return _enumerable.GetEnumerator();
            }
    
            IEnumerator IEnumerable.GetEnumerator()
            {
                return _enumerable.GetEnumerator();
            }
        }

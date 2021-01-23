    using System;
    using System.Collections;
    using System.Collections.Generic;
    
    namespace ConsoleApplication1
    {
    
        public class WrapperEnumerable<T> : IEnumerable<T>
        {
            private readonly IEnumerable _enumerable;
             
            public IEnumerator<T> GetEnumerator()
            {
                return new WrapperEnumerator<T>(_enumerable.GetEnumerator());
            }
    
            IEnumerator IEnumerable.GetEnumerator()
            {
                return _enumerable.GetEnumerator();
            }
    
            public WrapperEnumerable(IEnumerable enumerable)
            {
                _enumerable = enumerable;
            } 
        }
    
        public class WrapperEnumerator<T>:IEnumerator<T>
        {
            private readonly IEnumerator _enumerator;
    
            public T Current
            {
                get { return (T)Convert.ChangeType(_enumerator.Current,typeof(T)); }
            }
    
            public void Dispose()
            {           
            }
    
            object IEnumerator.Current
            {
                get { return _enumerator.Current; }
            }
    
            public bool MoveNext()
            {
                return _enumerator.MoveNext();
            }
    
            public void Reset()
            {
                _enumerator.Reset();
            }
    
            public WrapperEnumerator(IEnumerator enumerator)
            {
                _enumerator = enumerator;
            }
        }
    }

    public class LambdaEqualityComparer<T> : IEqualityComparer<T>
        {
            private Func<T,object> _action;
            public LambdaEqualityComparer(Func<T, object> action)
            {
                _action = action;
            }
    
            public bool Equals(T x, T y)
            {
                var areEqual = baseCheck(x, y) ?? baseCheck(getObj(x), getObj(y));
    
                if (areEqual != null)
                {
                    return areEqual.Value;
                }
    
                return _action(x).Equals(_action(y));
            }
    
            public int GetHashCode(T obj)
            {
                return _action(obj).GetHashCode();
            }
    
            /// <summary>
            /// True = return true
            /// False = return false
            /// null = continue evaluating
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            private bool? baseCheck(object x, object y)
            {
                if (x == null && y == null)
                {
                    return true;
                }
                else if (x == null || y == null)
                {
                    return false;
                }
    
                return null;
    
            }
    
            private object getObj(T t)
            {
                try
                {
                    return _action(t);
                }
                catch (NullReferenceException)
                {
    
                }
    
                return null;
            }
        }

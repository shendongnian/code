        public static TChild GetHierarchyChild<TParent, TChild>(this TParent parent)
            {
                var pType = typeof(TParent);
                var chType = typeof(TChild);
    
                var chPropInfo = pType
                                      .GetProperties()
                                      .FirstOrDefault(p => p.PropertyType == chType);
                if (chPropInfo == null)
                {
                    return default(TChild);
                    
                }
    
                return (TChild)chPropInfo.GetValue(parent);
            }
        public class A
        {
            public IEnumerable<B> Bs
            {
                get
                {
                    return new[] { new B(1) };
                }
            }
        }
    
        public class B
        {
            public B(int id)
            {
                Id = id;
            }
    
            public int Id { get; protected set; }
        }

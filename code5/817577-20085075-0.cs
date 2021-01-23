    public class Base
    {
        protected Base(Type type = null)
        {
            // 1. Base constructor code
            if (type != null)
            {
                // this will to InitializeEntity<type>();
                MethodInfo method = typeof(Base).GetMethod("InitializeEntity", BindingFlags.NonPublic | BindingFlags.Instance);
                MethodInfo generic = method.MakeGenericMethod(type);
                generic.Invoke(this, null);
            }
        }
        private void InitializeEntity<T>()
        {
            // 2. Initialize entities of class T
        }
    }
    public class Derived : Base
    {
        public Derived() : base(typeof(Entity))
        {
            // 3. Derived constructor code
        }
    }

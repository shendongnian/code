    public class A
    {
        public B MyBProperty { get; set; }
        public C MyCField;
    }
    public class B
    {
        public C MyCField;
    }
    public class C
    {
    }
    public class Creator
    { 
        static MethodInfo mi;
        static Creator()
        {
            mi = typeof(Creator).GetMethod("Create");
        }
        public T Create<T>()
        {
                var createdType = Activator.CreateInstance<T>();
            // assign all properties
            foreach (var p in typeof(T).GetProperties())
            {
                try
                {
                    var mig = mi.MakeGenericMethod(p.PropertyType);
                    p.SetValue(createdType, mig.Invoke(this, null));
                }
                catch
                {
                }
            }
            // assign all fields
            foreach (var f in typeof(T).GetFields())
            {
                try
                {
                    var mig = mi.MakeGenericMethod(f.FieldType);
                    f.SetValue(createdType, mig.Invoke(this, null));
                }
                catch
                {
                }
            }
            return createdType;
        }
    }
    // to use it:
    var c = new Creator();
    var a = c.Create<A>(); // should be instantiated

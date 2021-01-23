    public class IQUnionTag
    {
        private struct MyStruct<A, B, C>
        {
            public A value1;
            public B value2;
            public C value3;
        }
        
        private object MyStructure;
        private Type a;
        private Type b;
        private Type c;
        public IQUnionTag(Type a, Type b, Type c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            int d = 2;
            var d1 = typeof(MyStruct<,,>); // this is the way to get type of MyStruct
            Type[] typeArgs = { a, b, c };
            var makeme = d1.MakeGenericType(typeArgs);
            object o = Activator.CreateInstance(makeme);
            Console.WriteLine(o);
        }
    }

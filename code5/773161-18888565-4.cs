    using System.Runtime.Serialization;
    static class Program
    {
        static void Main()
        {
            var idgen = new ObjectIDGenerator();
            object foo = new object(), bar = new object(), blap = foo;
            Write(idgen, foo);
            Write(idgen, bar);
            Write(idgen, blap); // note this is the same object as foo
        }
        static void Write(ObjectIDGenerator idgen, object obj)
        {
            bool isNew;
            long id = idgen.GetId(obj, out isNew);
            System.Console.WriteLine("{0}, {1}", id, isNew);
        }
    }

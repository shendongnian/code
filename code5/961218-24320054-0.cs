    class Foo
    {
        public UInt32 One { get; set; }
        public UInt32 Two { get; set; }
        public UInt32 Three { get; set; }
        public UInt32 Four { get; set; }
        static public implicit operator byte[](Foo f)
        {
            MemoryStream m = new MemoryStream(16);
            BinaryWriter w = new BinaryWriter(m);
            w.Write(f.One);
            w.Write(f.Two);
            w.Write(f.Three);
            w.Write(f.Four);
            w.Close();
            m.Close();
            return m.ToArray();
        }
        static public explicit operator Foo(byte[] b)
        {
            Foo f = new Foo();
            MemoryStream m = new MemoryStream(b);
            BinaryReader r = new BinaryReader(m);
            f.One = r.ReadUInt32();
            f.Two = r.ReadUInt32();
            f.Three = r.ReadUInt32();
            f.Four = r.ReadUInt32();
            r.Close();
            m.Close();
            return f;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Foo f = new Foo() { One = 1, Two = 2, Three = 3, Four = 4 };
            byte[] b = (byte[])f;
            Console.WriteLine(b.Length);
            f = (Foo)b;
            Console.WriteLine("{0} {1} {2} {3}", f.One, f.Two, f.Three, f.Four);
            
            Console.ReadKey(true);
        }
    }

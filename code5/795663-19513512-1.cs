    class Program
    {
        static void Main(string[] args)
        {
            Base b = new Base(33);
            using (MemoryStream stream = new MemoryStream())
            {
                Serializer.Serialize<Base>(stream, b);
                Console.WriteLine("Length: {0}", stream.Length);
                stream.Seek(0, SeekOrigin.Begin);
                Foo f=new Foo();
                RuntimeTypeModel.Default.Deserialize(stream, f, typeof(Foo));
                Console.WriteLine("Foo: {0}", f.Counter);
            }
        }
    }

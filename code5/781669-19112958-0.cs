    using ProtoBuf;
    using ProtoBuf.Meta;
    using System;
    [ProtoContract]
    class Foo
    {
        [ProtoMember(1)]
        public double?[] Values { get; set; }
    }
    static class Program
    {
        static void Main()
        {
            // configure the model; SupportNull is not currently available
            // on the attributes, so need to tweak the model a little
            RuntimeTypeModel.Default.Add(typeof(Foo), true)[1].SupportNull = true;
    
            // invent some data, then clone it (serialize+deserialize)
            var obj = new Foo { Values = new double?[] {1,null, 2.5, null, 3}};
            var clone = Serializer.DeepClone(obj);
            // check we got all the values back
            foreach (var value in clone.Values)
            {
                Console.WriteLine(value);
            }
        }
    }

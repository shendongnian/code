    using System;
    using System.ComponentModel.Composition;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    namespace ConsoleApplication2
    {
        public enum SerialisationKind
        {
            Scalar,
            Array
        }
        [MetadataAttribute]
        public sealed class NetworkSerialisationAttribute: Attribute
        {
            public NetworkSerialisationAttribute(int ordinal, SerialisationKind kind = SerialisationKind.Scalar)
            {
                _ordinal = ordinal;
                _kind = kind;
            }
            public SerialisationKind Kind // Array or scalar?
            {
                get
                {
                    return _kind;
                }
            }
            public int Ordinal // Defines the order in which fields should be serialized.
            {
                get
                {
                    return _ordinal;
                }
            }
            private readonly int _ordinal;
            private readonly SerialisationKind _kind;
        }
        public static class NetworkSerialiser
        {
            public static byte[] Serialise<T>(T item)
            {
                using (var mem = new MemoryStream())
                {
                    serialise(item, mem);
                    mem.Flush();
                    return mem.ToArray();
                }
            }
            private static void serialise<T>(T item, Stream output)
            {
                var fields = item.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                var orderedFields = 
                    from    field in fields
                    let     attr = field.GetCustomAttribute<NetworkSerialisationAttribute>()
                    where   attr != null
                    orderby attr.Ordinal
                    select  new { field, attr.Kind };
                foreach (var info in orderedFields)
                {
                    if (info.Kind == SerialisationKind.Array)
                        serialiseArray(info.field.GetValue(item), output);
                    else
                        serialiseScalar(info.field.GetValue(item), output);
                }
            }
            private static void serialiseArray(object value, Stream output)
            {
                var array = (byte[])value; // Only byte arrays are supported. This throws otherwise.
                ushort length = (ushort) array.Length;
                output.Write(BitConverter.GetBytes(length), 0, sizeof(ushort));
                output.Write(array, 0, array.Length);
            }
            private static void serialiseScalar(object value, Stream output)
            {
                if (value is byte) // Byte is a special case; there is no BitConverter.GetBytes(byte value)
                {
                    output.WriteByte((byte)value);
                    return;
                }
                // Hacky: Relies on the underlying type being a primitive type supported by one
                // of the BitConverter.GetBytes() overloads.
                var bytes = (byte[])
                    typeof (BitConverter)
                    .GetMethod("GetBytes", new [] {value.GetType()})
                    .Invoke(null, new[] {value});
                output.Write(bytes, 0, bytes.Length);
            }
        }
        // In this class, note the use of the [NetworkSerialization] attribute to indicate
        // which fields should be serialised.
        public sealed class MyNetworkMessage
        {
            public MyNetworkMessage(byte[] data)
            {
                _data = data;
                _crc = 12345; // You should use Helper.CalcCrc(data);
            }
            public ushort Length
            {
                get
                {
                    return (ushort)_data.Length;
                }
            }
            public ushort Crc
            {
                get
                {
                    return _crc;
                }
            }
            public byte[] MessageData
            {
                get
                {
                    return _data;
                }
            }
            [NetworkSerialisation(0, SerialisationKind.Array)]
            private readonly byte[] _data;
            [NetworkSerialisation(1)]
            private readonly ushort _crc;
        }
        // In this struct, note how the [NetworkSerialization] attribute is used to indicate the
        // order in which the fields should be serialised.
        public struct MyOtherNetworkMessage
        {
            [NetworkSerialisation(5)]  public int Int1;
            [NetworkSerialisation(6)]  public int Int2;
            [NetworkSerialisation(7)]  public long Long1;
            [NetworkSerialisation(8)]  public long Long2;
            [NetworkSerialisation(3)]  public byte Byte1;
            [NetworkSerialisation(4)]  public byte Byte2;
            [NetworkSerialisation(9)]  public double Double1;
            [NetworkSerialisation(10)] public double Double2;
            [NetworkSerialisation(1)]  public short Short1;
            [NetworkSerialisation(2)]  public short Short2;
            public float ThisFieldWillNotBeSerialised;
            public string AndNeitherWillThisOne;
        }
        class Program
        {
            private static void Main(string[] args)
            {
                var test1 = new MyNetworkMessage(new byte[10]);
                var bytes1 = NetworkSerialiser.Serialise(test1);
                Console.WriteLine(bytes1.Length + "\n");
                var test2 = new MyOtherNetworkMessage
                {
                    Short1  = 1,
                    Short2  = 2,
                    Byte1   = 3,
                    Byte2   = 4,
                    Int1    = 5,
                    Int2    = 6,
                    Long1   = 7,
                    Long2   = 8,
                    Double1 = 9,
                    Double2 = 10
                };
                var bytes2 = NetworkSerialiser.Serialise(test2);
                Console.WriteLine(bytes2.Length);
                foreach (byte b in bytes2)
                {
                    Console.WriteLine(b);
                }
            }
        }
    }

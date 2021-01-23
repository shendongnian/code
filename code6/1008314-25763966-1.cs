    using ProtoBuf;
    using ProtoBuf.Meta;
    using System;
    using System.IO;
    
    [ProtoContract(SkipConstructor=true)]
    public class SerializableTestClass
    {
        [ProtoMember(1)]
        int _x { get; set; }
        [ProtoMember(2)]
        int _y { get; set; }
        [ProtoMember(3)]
        Vector3 _coords { get; set; }
    
        public SerializableTestClass()
        {
            _x = 10;
            _y = 20;
            _coords = Vector3.one * 2;
        }
    
        public void changeMembers()
        {
            _x += -3;
            _y += 134;
            _coords *= 3;
        }
    
        public override string ToString()
        {
            return _x.ToString() + " " + _y + " " + _coords;
        }
    }
    
    struct Vector3
    {
        public int x, y, z;
        public static Vector3 one = new Vector3 { x = 1, y = 1, z = 1 };
        public static Vector3 operator *(Vector3 value, int times)
        {
            return new Vector3
            {
                x = value.x * times,
                y = value.y * times,
                z = value.z * times
            };
        }
        public override string ToString()
        {
            return string.Format("({0}, {1}, {2})", x, y, z);
        }
    }
    class Program
    {
        static RuntimeTypeModel _model;
        static void Main()
        {
            _model = TypeModel.Create();
            _model.Add(typeof(Vector3), false).Add(1, "x").Add(2, "y").Add(3, "z");
            _model.Add(typeof(SerializableTestClass), true);
    
            SerializableTestClass testClass = new SerializableTestClass();
            var _serializedObject = new MemoryStream();
            testClass.changeMembers();
            Console.WriteLine("Original object: " + testClass.ToString());
            _model.Serialize(_serializedObject, testClass);
    
            _serializedObject.Position = 0;
            Console.WriteLine(_serializedObject.Length);
            SerializableTestClass test = (SerializableTestClass)_model.Deserialize(_serializedObject, null, typeof(SerializableTestClass));
            Console.WriteLine("Deserialized object: " + test.ToString());
        }
    }
 

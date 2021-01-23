    public class MyClass
        {
            [XmlArray("Items", IsNullable = true)]
            public ObservableCollection<Base> MyCollection { get; set; }
        }
        [XmlInclude(typeof(A))]
        [XmlInclude(typeof(B))]
        public class Base
        {
        }
        [XmlType("TypeA")]
        public class A : Base
        {
        }
        [XmlType("TypeB")]
        public class B : Base
        {
        }
        public static void Test()
        {
            var myClass = new MyClass() { MyCollection = new ObservableCollection<Base> { new A(), null, new B(), null } };
            var wtr = new StreamWriter("C:\\avp\\test.xml");
            var s = new XmlSerializer(typeof(MyClass));
            s.Serialize(wtr, myClass);
            wtr.Close();
        }

    using System;
    using System.Linq;
    using System.Reflection;
    using System.Xml.Serialization;
    [Serializable]
    public abstract class myBaseClass
    {
        [XmlIgnore]
        public virtual bool aBoolean { get; set; }
        public int anInt { get; set; }
    }
    [Serializable]
    public class myDerivedClass : myBaseClass
    {
        public string derivedString { get; set; }
    }
    [Serializable]
    public class overrideXmlIgnore : myBaseClass
    {
        // no XmlIgnore
        public override bool aBoolean
        {
            get
            {
                return base.aBoolean;
            }
            set
            {
                base.aBoolean = value;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // build array of types we can serialize/deserialize
            // uses Linq and Reflection namespaces
            Type[] derivedTypes = (from lAssembly in AppDomain.CurrentDomain.GetAssemblies()
                                   from lType in lAssembly.GetTypes()
                                   where typeof(myBaseClass).IsAssignableFrom(lType)
                                   select lType).ToArray();
            // build a test object to serialize with XMLIgnore still used
            myDerivedClass m = new myDerivedClass();
            m.aBoolean = true; // this property is ignored by default
            m.derivedString = "test";
            // set a file path to serialize to
            string testFilePath = "C:\\temp\\test.xml";
            // serialzie the object
            XmlSerializer x = new XmlSerializer(typeof(myBaseClass), derivedTypes);
            System.IO.StreamWriter sw = new System.IO.StreamWriter(testFilePath);
            x.Serialize(sw, m);
            sw.Close();
            // deserialize the object
            System.IO.StreamReader sr = new System.IO.StreamReader(testFilePath);
            myBaseClass deserializedObject = (myBaseClass)x.Deserialize(sr);
            sr.Close();
            // check the object's properties
            // aBoolean is false, even though the serialized object m set it to true, because of XmlIgnore
            Console.WriteLine("aBoolean = " + deserializedObject.aBoolean.ToString());
            // repeat process for the derived class that overrides and does not set XmlIgnore
            overrideXmlIgnore o = new overrideXmlIgnore();
            o.aBoolean = true;
            sw = new System.IO.StreamWriter(testFilePath);
            x.Serialize(sw, o);
            sw.Close();
            sr = new System.IO.StreamReader(testFilePath);
            deserializedObject = (myBaseClass)x.Deserialize(sr);
            // check the object's properties
            // aBoolean is true, as we no longer XmlIgnore
            Console.WriteLine("aBoolean = " + deserializedObject.aBoolean.ToString());
        }
    }

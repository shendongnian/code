    public interface IMainInterface
    {
        IClass1 @class { get; set; } // NOTICE ALL PROPERTIES WERE RENAMED TO MATCH THE JSON NAMES.
        List<IClass2> classes { get; set; }
    }
    [Serializable]
    [DataContract(Name = "MainClass")]
    [KnownType(typeof(Class1))]
    [KnownType(typeof(Class2))]
    public class MainClass : IMainInterface
    {
        public MainClass()
        {
            classes = new List<IClass2>();
        }
        [DataMember(Name = "class")]
        public IClass1 @class { get; set; }
        [DataMember(Name = "classes")]
        public List<IClass2> classes { get; set; }
    }
    [Serializable]
    [DataContract(Name = "class1")]
    public class Class1 : IClass1
    {
        public Class1() {}
        [DataMember(Name = "prop1")]
        public string prop1 { get; set; }
        [DataMember(Name = "prop2")]
        public string prop2 { get; set; }
        [DataMember(Name = "prop3")]
        public string prop3 { get; set; }
    }
    [Serializable]
    [DataContract]
    public class Class2 : IClass2
    {
        public Class2() { }
        [DataMember(Name = "propA")]
        public string propA { get; set; }
        [DataMember(Name = "propB")]
        public string propB { get; set; }
        [DataMember(Name = "propC")]
        public string propC { get; set; }
    }
    public interface IClass1
    {
        string prop1 { get; set; }
        string prop2 { get; set; }
        string prop3 { get; set; }
    }
    public interface IClass2
    {
        string propA { get; set; }
        string propB { get; set; }
        string propC { get; set; }
    }
    public static class TestJavaScriptConverter
    {
        public static void Test()
        {
            string json = @"
                {
                ""class"":
                    {""prop1"":""TestVal0"",""prop2"":""TestVal2"",""prop3"":""TestVal3""},
                ""classes"":
                    [
                        {""propA"":""A"",""propB"":""B"",""propC"":""C""},
                        {""propA"":""X"",""propB"":""Y"",""propC"":""Z""},
                        {""propA"":""1"",""propB"":""2"",""propC"":""3""}
                    ]
                }";
            var serializer = new JavaScriptSerializer();
            serializer.RegisterConverters(new JavaScriptConverter[] { new InterfaceToClassConverter<IClass1, Class1>(), new InterfaceToClassConverter<IClass2, Class2>() });
            var main1 = serializer.Deserialize<MainClass>(json);
            var json2 = serializer.Serialize(main1);
            Debug.WriteLine(json2);
            var main2 = serializer.Deserialize<MainClass>(json2);
            Debug.Assert(main1.@class.ToStringWithReflection() == main2.@class.ToStringWithReflection()); // No assert
            Debug.Assert(main1.classes.Select(c => c.ToStringWithReflection()).SequenceEqual(main2.classes.Select(c => c.ToStringWithReflection()))); // no assert
        }
    }

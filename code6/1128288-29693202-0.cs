    [ProtoContract]
    public class MyObject
    {
        [ProtoMember(1)]
        public string title { get; set; }
        [ProtoMember(2)]
        public int chapterIndex { get; set; }
        [ProtoMember(3)]
        public List<String> paragraphs { get; set; }
    }
    var myo = new[] 
    { 
        new MyObject
        {
            title = "some title 0",
            chapterIndex = 0,
            paragraphs = new List<string> { "p1", "p2", "p3", "p4" }
        }, 
        new MyObject
        {
            title = "some title 1",
            chapterIndex = 1,
            paragraphs = new List<string> { "p1chap1", "p2chap1", "p3chap1", "p4chap1" }
        }, 
    };
    byte[] bytes;
    using (var ms = new MemoryStream())
    {
        Serializer.Serialize(ms, myo);
        bytes = ms.ToArray();
    }
    using (var ms = new MemoryStream(bytes))
    {
        MyObject[] myo2 = Serializer.Deserialize<MyObject[]>(ms);
    }

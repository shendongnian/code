    public class HasOffset
    {
        public int Offset { get; set; }
    }
    var dto = new HasOffset { Offset = 1 };
    string json = dto.ToJson();
    json.Print(); //prints {"Offset":1}
    var fromJson = json.FromJson<HasOffset>();
    Assert.That(fromJson.Offset, Is.EqualTo(1));

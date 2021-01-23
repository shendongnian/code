    public class Test
    {
       public int id { get; set; }
       public string name { get; set; }
       public long revisionDate { get; set; }
    }
    public class Foo
    {
        public Test Name { get; set; }
    }
    // ...
    var output = JsonConvert.DeserializeObject<Foo>(json);
    lblOutput.Text = output.Name.name;

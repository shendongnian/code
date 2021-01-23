    public class SourceClass
    {
        public string Name { get; set; }
    }
    public class DestinationClass
    {
        public string Name { get; set; }
    }
    SourceClass c1 = new SourceClass() { Name = "Mr.Ram" };
    DestinationClass c2 = ObjectMapper.Mapper.Map<DestinationClass>(c1);

    public class MyObject
    {
        public MyObject()
        {
            
        }
        public MyObject(Enum e)
        {
            string text = System.IO.File.ReadAllText(fileName);
            var source = JsonConvert.DeserializeObject<MyObject>(text);            
            Mapper.CreateMap<MyObject, MyObject>();
            Mapper.Map(source, this);
        }
        public string Name { get; set; }
        
    }

    class Program
    {
        static void Main(string[] args)
        {
            string json = @"
            [
                {
                    ""ObjType"" : 1,
                    ""Objects"" : 
                    [
                        { ""Id"" : 1, ""Foo"" : ""One"" },
                        { ""Id"" : 2, ""Foo"" : ""Two"" },
                    ]
                },
                {
                    ""ObjType"" : 2,
                    ""Objects"" : 
                    [
                        { ""Id"" : 3, ""Bar"" : ""Three"" },
                        { ""Id"" : 4, ""Bar"" : ""Four"" },
                    ]
                },
            ]";
            List<Holder> list = JsonConvert.DeserializeObject<List<Holder>>(json);
            foreach (Holder holder in list)
            {
                if (holder.ObjType == 1)
                {
                    foreach (DerivedType1 obj in holder.Objects)
                    {
                        Console.WriteLine("Id: " + obj.Id + "  Foo: " + obj.Foo);
                    }
                }
                else
                {
                    foreach (DerivedType2 obj in holder.Objects)
                    {
                        Console.WriteLine("Id: " + obj.Id + "  Bar: " + obj.Bar);
                    }
                }
            }
        }
    }
    [JsonConverter(typeof(HolderConverter))]
    class Holder
    {
        public int ObjType { get; set; }
        public List<Base> Objects { get; set; }
    }
    abstract class Base
    {
        public int Id { get; set; }
    }
    class DerivedType1 : Base
    {
        public string Foo { get; set; }
    }
    class DerivedType2 : Base
    {
        public string Bar { get; set; }
    }

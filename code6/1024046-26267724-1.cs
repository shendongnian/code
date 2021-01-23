    public abstract class HalResource
    {
        public IDictionary<string, HalLink> Links { get; set; }
    }
    public abstract class HalResource<TEmbedded> : HalResource
    {
        public TEmbedded Embedded { get; set; }
    }
    public class HalLink
    {
        public string Href { get; set; }
    }
    public class FooDTO : HalResource<FooDTO.EmbeddedDTO>
    {
        public int X { get; set; }
        public class EmbeddedDTO
        {
            public int Y { get; set; }
            public int Z { get; set; }
        }
    }
    public class MyMappedFoo
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
    }
    class Program
    {
        public static void Main(params string[] args)
        {
            // Configure mapper manually
            var mapper = new Mapper();
            mapper.CreateMap<MyMappedFoo, FooDTO>();
            var myDTO = new FooDTO 
            { 
                X = 10, 
                Embedded = new FooDTO.EmbeddedDTO { Y = 5, Z = 9 } 
            };
            var mappedFoo = mapper.Map<MyMappedFoo, FooDTO>(myDTO);
            Console.WriteLine("X = {0}, Y = {1}, Z = {2}", mappedFoo.X, mappedFoo.Y, mappedFoo.Z);
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }

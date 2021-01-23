    public class CustomConverter : ITypeConverter<string, string>
    {
        public string Convert(ResolutionContext context)
        {
            return "translated in " + context.Options.Items["language"];
        }
    }
    internal class Program
    {
        private static void Main(string[] args)
        {
            AutoMapper.Mapper.CreateMap<string, string>().ConvertUsing<CustomConverter>();
            var result = AutoMapper.Mapper.Map<string, string>("value" , opt => opt.Items["language"] = "english");
            Console.Write(result); // prints "translated in english"
            Console.ReadLine();
        }
    }

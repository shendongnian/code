    public class NameValueMerger : ITypeConverter<IList<string>, IList<string>>
    {
        public IList<string> Convert(ResolutionContext context)
        {
            var source = context.SourceValue as IList<string>;
            var destination = context.DestinationValue as IList<string>;
            if (source != null &&
                destination != null)
            {
                return destination.Concat(source).ToList();
            }
            throw new ArgumentException("Types not compatible for converter.");
        }
    }
    public class NameValueContainer
    {
        public string Name { get; set; }
        public IList<string> Values { get; set; }
    }
    internal class Program
    {
        static Program()
        {
            Mapper.CreateMap<NameValueContainer, NameValueContainer>();
            Mapper.CreateMap<IList<string>, IList<string>>().ConvertUsing(new NameValueMerger());            
        }
        private static void Main(string[] args)
        {
            var first = new NameValueContainer { Name = "First", Values = new List<string> { "Value1", "Value2" } };
            var second = new NameValueContainer { Name = "Second", Values = new List<string> { "Value3" } };
        
            var result = Mapper.Map(second, first);
            Console.Write("Value : " + string.Join(", ", result.Values));
            Console.WriteLine();
        }
    }

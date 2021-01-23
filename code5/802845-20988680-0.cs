    class Program
    {
        static void Main()
        {
            Mapper.CreateMap<SearchQuery, GetPersonsQuery>();
            var source = new SearchQuery {Id = Guid.NewGuid(), Text = Guid.NewGuid().ToString() };
            Console.WriteLine("Src: id = {0} text = {1}", source.Id, source.Text);
            var target = Mapper.Map<SearchQuery, GetPersonsQuery>(source);
            Console.WriteLine("Tgt: id = {0} text = {1}", target.Id, target.Text);
            Console.ReadLine();
        }
    }
    internal class GetPersonsQuery
    {
        private readonly Guid _id = new Guid("11111111-97b9-4db4-920d-2c41da24eb71");
        public Guid Id { get { return _id; } }
        public string Text { get; set; }
    }
    internal class SearchQuery
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
    }

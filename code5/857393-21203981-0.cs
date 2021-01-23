    class Program
    {
        static void Main(string[] args)
        {
            var collection = new List<DynamicNode>(){
                new DynamicNode { Id = "1", Name = "name1"},
                new DynamicNode { Id = "2", Name = "name2"}
            };
            //Getting Ids using extension methods and lambda expressions
            string[] Ids = collection.Select(x => x.Id).ToArray();
            foreach (string id in Ids)
                Console.WriteLine(id);
            //Gettings ids using linq expression
            var linqIds = from s in collection
                               select s.Id;
            string[] lIds = linqIds.ToArray();
            foreach (string id in lIds)
                Console.WriteLine(id);
            Console.Read();
        }
    }
    class DynamicNode
    {
        public string Id { get; set;}
        public string Name { get; set; }
    }

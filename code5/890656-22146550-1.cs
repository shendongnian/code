    class Program
    {
        static void Main(string[] args)
        {
            List<MyData> DICT_list = new List<MyData>()
            {
               new MyData{ Dictionay="Aplha", Dimension="Length", Classes="Process"},
               new MyData{ Dictionay="Aplha", Dimension="breath", Classes="Activity"},
               new MyData{ Dictionay="Aplha", Dimension="Height", Classes="Workflow"},
               new MyData{ Dictionay="Beta", Dimension="Height", Classes="Workflow"},
               new MyData{ Dictionay="Beta", Dimension="Length", Classes="Workflow"}
            };
            var query = DICT_list.Where(d => d.Dimension == "Length" && d.Dictionay == "Aplha")
                     .Select(d => d.Classes);
            foreach (var VARIABLE in query)
            {
                Console.WriteLine(VARIABLE.ToString());
            }
            Console.ReadLine();
        }
    }

    class ListKeywords
    {
        public int ID { set; get; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var myList = new List<ListKeywords>();
            Random rnd = new Random();
            for (int i = 0; i < 3000; i++)
            {
                var entry = new ListKeywords() { ID = rnd.Next(3000, 9999) };
                myList.Add(entry);
            }
            myList = SortByIdAndReturnRange(myList, 1000);
            foreach (var entry in myList)
            {
                Console.WriteLine(entry.ID);
            }
        }
        static List<ListKeywords> SortByIdAndReturnRange(List<ListKeywords> list, int range)
        {
            return list.OrderBy(x => x.ID).Take(range).ToList();
        }
    }

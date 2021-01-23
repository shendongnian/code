     class Program
    {
        static void Main()
        {
            List<string> a = new List<string>();
            a.Add("[1] MS Excel documentation");
            a.Add("[2] MS Excel tutorial");
            a.Add("[3] MS Access documentation");
            a.Add("[4] MS Access tutorial");
            a.Add("[5] Google Chrome documentation");
            a.Add("[6] Google Product video for Chrome");
            string search = "MS documentation";
            var result = a.WhereExtension(search);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
    public static class MyExtensions
    {
        public static List<string> WhereExtension(this List<string> source, string items)
        {
            var search = items.Split(' ');
            List<string> list = new List<string>();
            foreach (string item in source)
            {
                bool add = true;
                for (int i = 0; i < search.Count(); i++)
                {
                    if (!item.Contains(search[i]))
                        add = false;
                }
                if (add == true)
                    list.Add(item);
            }
            return list;
        }
    }

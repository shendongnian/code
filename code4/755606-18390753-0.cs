    public class Place
    {
        private string[][] places = new string[2][]
        {
            new string[] { "Canada", "United States" },
            new string[] { "Calgary", "Edmonton", "Toronto" },
        };
    
        public void enumerate()
        {
            Console.WriteLine(places[0][1]);
        }
    }

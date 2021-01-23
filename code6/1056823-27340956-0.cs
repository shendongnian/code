    class Program
    {
        static void Main(string[] args)
        {
            string dicName = "Group";
            var fishInfo = new FishInformation();
            string myKey = "myKey";
            int myValue = 1;
            fishInfo.Dictionaries[dicName][myKey] = myValue;
        }
    }
    
    public class FishInformation
    {
        public FishInformation()
        {
            Dictionaries = new Dictionary<string, Dictionary<string, int>>()
            {
                { "Group", new Dictionary<string, int>() },
                { "Event", new Dictionary<string, int>() },
                { "Audience", new Dictionary<string, int>() },
                { "Type", new Dictionary<string, int>() }
            };
        }
    
        public int FishId { get; set; }
    
        public Dictionary<string, Dictionary<string, int>> Dictionaries { get; set; }
        public Dictionary<string, int> GroupDic
        {
            get { return Dictionaries["Group"]; }
        }
        // ... other dictionary getters ...
    }

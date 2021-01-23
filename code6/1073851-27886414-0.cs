    namespace StackOverflow27884119
    {
        public enum Level
        {
            Easy,
            Medium,
            Hard
        }
    
        class Program
        {
            private static Dictionary<int, Level> mapsDictionary = new Dictionary<int, Level>()
                    {
                        {7, Level.Easy}, {10, Level.Easy}, {3, Level.Easy}, {44, Level.Easy},
                        {17, Level.Medium}, {14, Level.Medium}, /*...*/ {111, Level.Medium},
                        {92, Level.Hard}, {98, Level.Hard}, {112, Level.Hard}, {145, Level.Hard},
                    };
    
            static void Main(string[] args)
            {
                var mapId = 3;
                SpawnItem(3);
            }
    
            private static void SpawnItem(int mapId)
            {
                Level level;
                bool found = mapsDictionary.TryGetValue(mapId, out level);
                if (found)
                {
                    switch (level)
                    {
                        case Level.Easy:
                            // spawn common_item
                            break;
                        case Level.Medium:
                            // spawn common_item
                            // spawn uncommon_item
                            break;
                        case Level.Hard:
                            // spawn common_item
                            // spawn uncommon_item
                            // spawn rare_item
                            break;
                    }
                }
            }
        }
    }

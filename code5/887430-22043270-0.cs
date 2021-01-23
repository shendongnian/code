    public partial class ActionType
    {
        public string Id { get; set; }
        public string FName { get; set; }
        public static IEnumerable<ActionType> GetDefaultActionTypes() { 
            return new List<ActionType> {
                new ActionType { Id = "2", FName = "hanumanji" },
                new ActionType { Id = "4", FName = "temples" },
                new ActionType { Id = "28", FName = "books" },
                new ActionType { Id = "38", FName = "stories" },
            };
        }
    }

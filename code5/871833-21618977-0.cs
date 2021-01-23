    public class Program
    {
        public class Model {
            public string Number { get; set; }
        }
        
        private static List<Model> getSearchResults(List<Model> models) 
        {
            List<Model> result = models.Where(m => m.Number.Contains("3330")).ToList();
        
            return result;
        }
        
        public static void Main()
        {
            List<Model> list = new List<Model>() {
                new Model() { Number = "13330A"},
                new Model() { Number = "13230A"},
                new Model() { Number = "3330A"},
                new Model() { Number = "543330"},
                new Model() { Number = "48913"},
                new Model() { Number = "97798133"},
                new Model() { Number = "542130"}
            };
            
            foreach(Model v in getSearchResults(list)) {
                Console.WriteLine(v.Number);
            }      
        }
    }

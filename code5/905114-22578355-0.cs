        public class ValuesController : ApiController
        {
            private Dictionary<string, string> values = new Dictionary<string, string> 
            { 
                {"a", "aaaaaa"}, 
                {"b", "bbbbb"}, 
                {"c", "ccccccc"}
            };
 
            public Dictionary<string, string> Get()
            {
                return values;
            }
        }

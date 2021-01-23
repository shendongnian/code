        /// <summary>
        /// Your entity
        /// </summary>
        public class Events
        {
            public int EventID { get; private set; }
            public string Name { get; set; }
            public DateTime EventDate { get; set; }
        }
    
        public class Program
        {
            static void Main(string[] args)
            {
                // Query all events
                IEnumerable<Events> events = null; 
                            
                // Group them by Date
                events
                    .GroupBy(e => e.EventDate)
                    .Select(g => new
                    {
                        Date = g.Key,
                        Count = g.Count()
                    });
            }
        }

        private static List<Event> GetEvents()
        {
            var events = new List<Event> {
                new Event
                {
                    EventID = 1,
                    EventTime =  new DateTime(2015, 5, 15, 13, 45, 0),
                    ProductID = 1,
                },
            };
            return events;
        }

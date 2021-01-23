    private static object ObjectTuple()
            {
                return new { Name = "Nick", Age = "Twenty" };
            }
    
            private static dynamic DynamicTuple()
            {
                return new { Name = "Nick", Age = "Twenty" };
            }
    
            private static Temp TempTuple()
            {
                return new Temp{ Name = "Nick", Age = "Twenty" };
            }
    
            class Temp
            {
                public string Name { get; set; }
                public string Age { get; set; }
            }

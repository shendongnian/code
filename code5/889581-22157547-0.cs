    public class ClassSecond
        {
            public string Name { get; set; }
            public int Height { get; set; }
            public int Weight { get; set; }
    
                
            public ClassSecond(string name = "Ben")
            {
                Name = name;
               
            }
    
            public ClassSecond(string name = "Ben", int height = 100): this (name)
            {
    
                Height = height;    
            }
    
            public ClassSecond(string name = "Ben", int height = 100, int weight = 20): this (name, height)
               
            {
                Weight = weight;
            }
    
    
    
    
    
    
    
        }

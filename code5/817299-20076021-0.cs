    public static class YourClass
    {
        public enum Brand { Brand1, Brand2 }
        private static Dictionary<Brand, string> Descriptions {get; set;}
    
        static YourClass()
        {
            YourClass.Descriptions.Add(Brand.Brand1, "Friendly name 1");
            YourClass.Descriptions.Add(Brand.Brand2, "Friendly name 2");
        }
    
        public static string ToDescription(this Brand brand) 
        {
            // error checking left out
            return YourClass.Descriptions[brand];
        }
    }

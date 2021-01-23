     [AttributeUsage(System.AttributeTargets.All, AllowMultiple = false)]
     public sealed class UnitAttribute : Attribute
     {
            public UnitAttribute(UnitTypes type)
            {
                Units = type;
            }
    
        public UnitTypes Units { get; private set; }
     }
     public enum UnitTypes
     {
            Bag,
            Bottle,        
            Box,
            Bunch,
            Case,
            Can,
            Cup,
            Dozen,
            Gallon,
            Item,
            Jar,
            Ounce,
            Pouch, 
            Pound,        
            Pack,
            Roll,
            Stick,
            TableSpoon,
            TeaSpoon
      }

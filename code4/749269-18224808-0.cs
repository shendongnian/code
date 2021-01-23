        public class Category
          {
            internal Category() {};
            public string Id; // This would be used to understand what you got, can be a list of enums or something
          }
          public static Category CrateCategory = new Category {Id = "Wood.Crate"};
          public static class Wood
          {
            // either way will work, one will let you directly access CrateCategory (if that is what you wish), the second will remove the need for different Crate categories
            public static Category Crate { get { return CrateCategory; } }
            public static Category Box { get { return new Category { Id = "Wood.Box" }; } }
          }

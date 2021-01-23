        public enum Ingredient = { Wood, Stone, Water, Gold/*and so on*/ };
        public class RecipeItem 
        {
                public Ingredient Ingredient{ get; set;}
                public int Amount {get; set;}
        }
        public class Recipe
        {
                public string Name {get; set;}
                public List<RecipeItem> RecipeItems {get;set;}
        }

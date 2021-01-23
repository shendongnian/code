    public class Program
    {
        static void Main()
        {
    
            var allRolls = new List<Roll>
            {
                new Roll
                {
                    Name = "Roll 1",
                    Ingredients = { "IngredientA", "Crab", "IngredientC" }
                },
                new Roll
                {
                    Name = "Roll 2",
                    Ingredients = { "IngredientB", "IngredientC" }
                },
                new Roll
                {
                    Name = "Roll 3",
                    Ingredients = { "Crab", "IngredientA" }
                }
            };
    
    
            var rollsWithCrab = allRolls.Where(roll => roll.Contains("Crab"));
            foreach (Roll roll in rollsWithCrab)
            {
                Console.WriteLine(roll.Name);
            }
        }
    }

    static object doSomething()
    {
        // Even though it’s a lie…
        return new { IsFoodTasty = true, FoodType = "Angelfood Cake", };
    }
    
    public static void Main()
    {
        dynamic foodInfo = doSomething();
        Console.WriteLine(foodInfo.IsFoodTasty ? "Food {0} tastes good." : "Food {0} tastes bad.", foodInfo.FoodType);
    }

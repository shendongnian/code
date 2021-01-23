    public static void Main(strig[] args) {
        IWorld world = Universe.Instance.CreateWorld("Solarius");
        Console.WriteLine(world.Age); //Prints out the world's age
        Universe.Instance.DestroyWorld(ref world);
        Console.WriteLine(world.Age); // NullReferenceException
    }

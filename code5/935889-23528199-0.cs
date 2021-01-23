    public class FirstConcreteMachineModel : IMachineModel
    {
        public string Model { get; set; }
        public void DoSomething()
        {
            Console.WriteLine("I am a machine of type 1");
        }
    }
    public class SecondConcreteMachineModel : IMachineModel
    {
        public string Model { get; set; }
        public void DoSomething()
        {
            Console.WriteLine("I am a machine of type 2");
        }
    }
    public class MachineModelFactory
    {
        public static IMachineModel CreateMachineModel(string type)
        {
            //switch with all possible types
            switch (type)
            {
                case "one":
                    return new FirstConcreteMachineModel { Model = type };
                case "two":
                    return new SecondConcreteMachineModel { Model = type };
                default:
                    throw new ArgumentException("Machine type not supported");
            }
            
        }
    }

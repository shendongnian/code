    class Program
    {
        static void Main(string[] args)
        {
            State fullState = State.Full;
    
            Console.WriteLine(fullState.Description());
            Console.WriteLine(State.HalfFull.Description());
                
            Console.ReadLine();
        }
    }
    
    public enum State
    {
        Empty,
        Full,
        HalfFull
    }
    
    public static class StateExtensions
    {
        private static Dictionary<State, string> descriptions = new Dictionary<State, string>();
    
        static StateExtensions()
        {
            descriptions.Add(State.Empty, "It's just empty");
            descriptions.Add(State.Full, "It's so full");
            descriptions.Add(State.HalfFull, "It's got something in it");
        }
    
        public static string Description(this State state)
        {
            return descriptions[state];
        }
    }

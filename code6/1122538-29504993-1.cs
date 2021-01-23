    // Base Abstract Class
    public abstract class Avenger
    {
        public abstract string MyIdentity { get; }
    }
    // Not implementing MyIdentity results in compile error
    public class Hulk : Avenger
    { }

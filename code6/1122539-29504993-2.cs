    // Base Abstract Class
    public abstract class Avenger
    {
        public abstract string MyIdentity { get; }
    }
    // Derrived class implements abstract member
    public class Hulk : Avenger
    {
        public override string MyIdentity
        {
            get { throw new NotImplementedException("Won't tell"); }
        }
    }

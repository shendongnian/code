    // Try not to use nested types unless there's a clear benefit.
    public enum Difficulty { Easy, Normal, Hard }
    public class Foo
    {
        // Declares a property of *type* Difficulty, and with a *name* of Difficulty
        public Difficulty Difficulty { get; set; }
    }

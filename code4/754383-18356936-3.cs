    public abstract class WithID
    {
        // public int ID; // non readonly
        public readonly int ID; // can even be a field
    }
    public static void createDictionary<T>(IEnumerable<T> myRecords)
            where T: WithID

    public interface IWithID
    {
        // For your method the set(ter) isn't necessary
        // public int ID { get; set; } 
        public int ID { get; }
    }
    public static void createDictionary<T>(IEnumerable<T> myRecords)
            where T: IWithID

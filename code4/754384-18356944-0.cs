    public interface IIDInterface {
         int ID { get; set; }
    }
    public static void createDictionary<T>(IEnumerable<T> myRecords)
                where T: IIDInterface

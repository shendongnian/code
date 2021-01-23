    public class UniqueEntity<T> where T : IComparable, IComparable<T>
    {
         [Key]
         public T Key { get; set; }
    }

    public class ProductCollection<T> : IEnumerable<T>
      where T : Product
    {
      public int Id { get; set; }
      public string CollectionName { get; set; }
      public virtual ICollection<T> Products { get; set; }
      public bool Listed { get; set; }
      // This is all it takes to implement IEnumerable<T>
      public IEnumerator<T> GetEnumerator()   { return this.Products.GetEnumerator(); }
      IEnumerator IEnumerable.GetEnumerator() { return this.Products.GetEnumerator(); }
    }

        public interface IObject<T> where T : IObject<T>
        {
          double x { get; }
          double y { get; }
          Holder<T> Holder { get; set; }
        }
    
    
        public class Holder<T> where T : IObject<T>
        {
          public Holder()
          {
            items = new List<T>();
          }
          private List<T> items;
          public void AddItem(T item)
          {
            items.Add(item);
            item.Holder = this;
          }
        }
    
        public class Implementation : IObject<Implementation>
        {
    
          public double x
          {
            get { return 0; }
          }
    
          public double y
          {
            get { return 0; }
          }
    
          public Holder<Implementation> Holder
          {
            get;
            set;
          }
        }
        static void Main(string[] args)
        {
          var t = new Holder<Implementation>();
          t.AddItem(new Implementation());
          Console.ReadKey();
        }

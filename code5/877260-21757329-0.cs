    public class Disposed : IDisposable
    {
        public bool IsDisposed { get; private set; }
        public DateTime? Created { get; set; }
    
        public void Dispose()
        {
            Console.WriteLine("Disposed");
            IsDisposed = true;
        }
    }
    public IEnumerable<Disposed> GetDisposed()
    {
        Func<Disposed> factory = () => new Disposed { Created = DateTime.Now };
        foreach(var f in Enumerable.Repeat(factory, 5))
        {
            Console.WriteLine("In Enumerable");
            var item = f();
            try
            {
                Console.WriteLine("Returning item");
                yield return item;
            }
            finally
            {
                item.Dispose();
            }
            
            Console.WriteLine("Next iteration.");
        }
    }

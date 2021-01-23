    try
    {
      //caller
      using (var x = new Disposable1()) { }
    }
    catch (Exception ex)
    {
       Debug.WriteLine(ex.Message);
    }
    public class Disposable1 : IDisposable
    {
        private Disposable2 first = new Disposable2();
        private Disposable2 second;
        public Disposable1()
        {
            second = new Disposable2("Goodbye!");
        }
        public void Dispose()
        {
            Debug.WriteLine("Disposable1.Dispose()");
            first.Dispose();
            if (second != null)
                second.Dispose();
        }
    }
    public class Disposable2 : IDisposable
    {
        public string Whatever { get; set; }
        public Disposable2() { Whatever = "Hello!"; }
        public Disposable2(string whatever)
        {
            Whatever = whatever;
            throw new Exception("Doh!");
        }
        public void Dispose()
        {
            Debug.WriteLine("Disposable2.Dispose()" + Whatever);
        }
    }

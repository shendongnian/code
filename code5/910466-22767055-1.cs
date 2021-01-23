    public class Class1
    {
        // public delegate void MyDelegate(string key, DateTime date, int value);
    
        public event EventHandler Foo;
        public event EventHandler Bar;
        // public event MyDelegate Cancel;
    
        public void Raise()
        {
            this.Bar(null, EventArgs.Empty);
            // this.Cancel(null, DateTime.Now, 4);
        }
    }

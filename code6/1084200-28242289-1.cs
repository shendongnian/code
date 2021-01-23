    class Program
    {
        static void Main(string[] args)
        {
            MyObject a1 = null, a2 = null;
            MyObject.Create(i => a1 = i);
            MyObject.Create(i => a2 = i);
            Console.WriteLine("a1 hashcode:" + a1.GetHashCode()); // 46104728
            Console.WriteLine("a2 hashcode:" + a2.GetHashCode()); // 12289376
            a1.SwapWith(a2);
            Console.WriteLine("a1 hashcode:" + a1.GetHashCode()); // 12289376
            Console.WriteLine("a2 hashcode:" + a2.GetHashCode()); // 46104728
        }
    }
    class MyObject
    {
        private Action<MyObject> _assigner;
        private MyObject() { }
        public static void Create(Action<MyObject> assigner = null)
        {
            var newInstance = new MyObject();
            newInstance._assigner = assigner;
            newInstance.Assign();
        }
        public void SwapWith(MyObject replacement)
        {
            replacement._assigner = Interlocked.Exchange(ref this._assigner, replacement._assigner);
            this.Assign();
            replacement.Assign();
        }
        private void Assign()
        {
            if (_assigner != null) _assigner(this);
        }
    }

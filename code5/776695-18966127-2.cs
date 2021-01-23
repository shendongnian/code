    class Example {
        private int x;
        public int GetX() {return x;}
        public void SetX(int value) { x = value;}
    }
    Example e = new Example();
    e.SetX(123);
    Console.WriteLine("X = {0}", e.GetX());

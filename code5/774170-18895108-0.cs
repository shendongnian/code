    public class Example
    {
        private Dictionary<string, Action> _map = new Dictionary<string, Action>();
        public Example()
        {
            _map["A"] = A;
            _map["B"] = B;
            _map["C"] = C;
        }
        public void A() { }
        public void B() { }
        public void C() { }
        public void CallByString(string func)
        {
            if(_map.ContainsKey(func))
                _map[func]();
        }
    }

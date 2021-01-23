    public class Names
    {
        private string[] _names = {"", "", ""};
        public string[] Names { get {return _names; } } // ReadOnlyCollection?
        public string Name1
        {
           get { return _names[0]; }
           set { _names[0] = value; }
        }
    }

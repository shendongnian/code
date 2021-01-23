    public class _standing
    {
        public string name { get; set; }
        public int position { get; set; }
        public _standing(string _name, int _pos)
        {
            name = _name;
            position = _pos;
        }
        public override string ToString()
        {
            return position + ": " + name;
        }
    }

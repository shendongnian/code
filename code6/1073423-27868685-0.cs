    public struct Rec
    {
        public Rec(string match)
        {
            Match=match;
            Extensions=new List<string>();
        }
        public string Match { get; private set; }
        public List<string> Extensions { get; private set; }
        public void Push(params string[] ext)
        {
            if(ext.Contains("ALL__"))
            {
                Extensions=new List<string>() { "*" };
                return;
            }
            if(Extensions.Intersect(ext).Any())
            {
                return;
            }
            Extensions.AddRange(ext);
        }
    }

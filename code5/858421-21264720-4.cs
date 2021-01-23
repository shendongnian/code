    public class RuleField
    {
        public string Name { get; set; }
        public string Header { get; set; }
        int _Position = 0;
        public int Position
        {
            get
            {
                return _Position;
            }
        }
        public RuleField(int position)
        {
            _Position = position;
        }
    }

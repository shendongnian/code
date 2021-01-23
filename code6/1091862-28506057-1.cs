    [DebuggerDisplay("{Name}")]
    [DebuggerTypeProxy(typeof (RuleDebugView))]
    public class Rule
    {
        public string Name;
        public int MaxAge;
        public DateTime StartDate;
        public DateTime EndDate;
        internal class RuleDebugView
        {
            public string _1_Name;
            public int _2_MaxAge;
            public DateTime _3_StartDate;
            public DateTime _4_EndDate;
            public RuleDebugView(Rule rule)
            {
                this._1_Name = rule.Name;
                this._2_MaxAge = rule.MaxAge;
                this._3_StartDate = rule.StartDate;
                this._4_EndDate = rule.EndDate;
            }
        }
    }

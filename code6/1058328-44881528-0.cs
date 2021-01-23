    public class State
    {
            [Newtonsoft.Json.JsonProperty]
            public double Citizens { get; private set; }
    
            [Newtonsoft.Json.JsonProperty]
            public float Value { get { return pValue; } }
            private float pValue = 450000.0f;
            public List<string> BeachList { get; } = new List<string>();
        public State()
        {
        }
        public State(double _Citizens)
        {
            this.Citizens = _Citizens;
        }
    }
    ...
    
                State croatia = new State(30.0D);
                croatia.BeachList.Add("Bol na Braču");
                croatia.BeachList.Add("Zrće");
    
               string croatiaSerialized = Newtonsoft.Json.JsonConvert.SerializeObject(croatia);
    
               State slovenia = Newtonsoft.Json.JsonConvert.DeserializeObject<State>(croatiaSerialized);

    namespace Objects
    {
        public class Project
        {
            public Dictionary<string, Variable> Variables { get; set; }
        }
        public  class Variable
        {
            public object Value { get; set; }
        }
    }

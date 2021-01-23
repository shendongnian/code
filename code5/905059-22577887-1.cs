    // builder
    public class ProblemStatement
    {
        List<SqlParameter> list = new List<SqlParameter>();
        
        // single parameter
        public ProblemStatement Title(string value)
        {
           list.Add("strProblemTitle", value);
           return this;
        }
        public ProblemStatement Owner(string value)
        {
           list.Add("strProblemOwner", value);
           return this;
        }
        public ProblemStatement Description(string value)
        {
           list.Add("strProblemOwner", value);
           return this;
        }
        // a couple of parameters together at once...
        public ProblemStatement AddProblem(string title, 
                                           string owner, 
                                           string description)
        {
           return Title(title)
                  .Owner(owner)
                  .Description(description); // re-use methods
        }
        
        public SqlParameter[] ToArray()
        {
            return list.ToArray();
        }
    }

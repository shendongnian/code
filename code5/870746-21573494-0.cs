    interface IX
    {
        public string Var {get;}
    }
    public class X : IX
    {
        string IX.Var { get { return "x"; } }
    }
    public class Y
    {
        public Y()
        {
            X x = new X();
            string s = x.Var; // Var is not visible and gives a compilation error.
            string s2 = ((IX)x).Var; // this works. Var is not hidden when using interface directly.
        }
    }

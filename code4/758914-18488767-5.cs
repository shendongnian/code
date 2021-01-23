    public class Member
    {
        // can be private/protected/internal
        public static readonly Expression<Func<Member, string>> RealNameExpression =
            m => (m.Name + " " + m.LastName).TrimEnd();
        // Here we are referencing another "special" property, and it just works!
        public static readonly Expression<Func<Member, string>> DisplayNameExpression =
            m => string.IsNullOrEmpty(m.ScreenName) ? m.RealName : m.ScreenName;
        public string RealName
        {
            get 
            { 
                // return the real name however you want, probably reusing
                // the expression through a compiled readonly 
                // RealNameExpressionCompiled as you had done
            }  
        }
        public string DisplayName
        {
            get
            {
            }
        }
    }
    // Note the use of .Expand();
    var res = (from p in ctx.Member 
              where p.RealName == "Something" || p.RealName.Contains("Anything") ||
                    p.DisplayName == "Foo"
              select new { p.RealName, p.DisplayName, p.Name }).Expand();
    // now you can use res normally.

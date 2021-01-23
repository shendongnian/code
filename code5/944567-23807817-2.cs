    using System.Collections.Specialized;
    using System.Web;
    namespace Test   
    {
        class Foo
        {
            public Foo()
            {
                NameValueCollection foo = HttpUtility.ParseQueryString("data");
            }
        }
    } 

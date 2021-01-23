    //username=bob&password=123&a=Cheese&b=Chocolate&a=Cat&b=Dog
    public class LoginRequest
    {
        public string username { get; set; }
        public string password { get; set; }
        public List<OtherClass> d { get; set; }
    }
    
    public class OtherClass
    {
        public string a { get; set; }
        public string b { get; set; }
    }
    
    static void Main(string[] args)
    {
        var request = new LoginRequest
        {
            username = "bob",
            password = "123",
            d = new List<OtherClass> { new OtherClass { a = "Cheese", b = "Chocolate" } ,
            new OtherClass { a = "Cat", b = "Dog" } }
        };
    
        Console.WriteLine(ObjectToQueryString(request));
        Console.ReadLine();
    }
    
    private static string ObjectToQueryString<T>(T obj) where T : class
    {
        StringBuilder sb = new StringBuilder();
    
        IEnumerable data = obj as IEnumerable ?? new[] { obj };
    
        foreach (var datum in data)
        {
            Type t = datum.GetType();
            var properties = t.GetProperties();
            foreach (PropertyInfo p in properties)
            {
                if (p.CanRead)
                {
                    var indexes = p.GetIndexParameters();
                    if (indexes.Count() > 0)
                    {
                        var pp = p.GetValue(datum, new object[] { 1 });
                        sb.Append(ObjectToQueryString(pp));
                    }
                    else if (typeof(IEnumerable).IsAssignableFrom(p.PropertyType) && p.PropertyType  != typeof(string))
                    {
                        sb.Append(ObjectToQueryString(p.GetValue(datum)));
                    }
                    else
                    {
    
                        //I dont think this is a good way to do it
                        if (p.PropertyType.FullName != p.GetValue(datum, null).ToString())
                        {
                            //sb.Append(String.Format("{0}={1}&", p.Name, HttpUtility.UrlEncode(p.GetValue(datum, null).ToString())));
                            sb.Append(String.Format("{0}={1}&", p.Name, p.GetValue(datum, null).ToString()));
                        }
                        else
                        {
                            sb.Append(ObjectToQueryString(p.GetValue(datum, null)));
                        }
                    }
                }
            }
        }
        return sb.ToString().TrimEnd('&');
    }

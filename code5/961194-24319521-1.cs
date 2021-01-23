    /// <summary>
    /// A Class to allow simulation of SessionObject
    /// </summary>
    public class MockHttpSession : HttpSessionStateBase
    {
        Dictionary<string, object> m_SessionStorage = new Dictionary<string, object>();
        public override object this[string name]
        {
            get {
                try
                {
                    return m_SessionStorage[name];
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            set { m_SessionStorage[name] = value; }
        }
    }
    public class RequestParams : System.Collections.Specialized.NameValueCollection
    {
        Dictionary<string, string> m_SessionStorage = new Dictionary<string, string>();
        public override void Add(string name, string value)
        {
            m_SessionStorage.Add(name, value);
        }
        public override string Get(string name)
        {
            return m_SessionStorage[name];
        }
        /*
        public override string this[string name]
        {
            get { return m_SessionStorage[name]; }
            set { m_SessionStorage[name] = value; }
        }
         * */
    }
    public class MockServer : HttpServerUtilityBase
    {
        public override string MapPath(string path)
        {
            return @"C:\YourCodePathTowherever\" + path;
        }
    }

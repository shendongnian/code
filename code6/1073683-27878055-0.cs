    public static class Foo
    {
        private static Dictionary<string,string> m_Constants = new Dictionary<string,string>();
        static Foo()
        {
            m_Constants["Foo"] = "Hello";
            // etc
        }
        public static string GetConstant( string key )
        {
            return m_Constants[key];
        }
    }
    public string Bar( string constName )
    {
        return Foo.GetConstant( constName );
    }

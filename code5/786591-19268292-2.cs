    public class Global : System.Web.HttpApplication
    {
        public static readonly Dictionary<string, string> TEST_DICT
                  = new Dictionary<string, string> {
                {"rad1", "value1"},
                {"rad2", "value2"},
                {"rad3", "value3"},
                {"rad4", "value4"},
            };
    }

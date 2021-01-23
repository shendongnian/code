        public class RegexUtility
        {
            private static readonly Lazy<RegexUtility> _instance
                = new Lazy<RegexUtility>(() => new RegexUtility());
            private static Lazy<Regex> _radioButton = new Lazy<Regex>(() => new Regex(@"<input.*type=.?radio.*?>"));
            public static Regex RadioButton
            {
                get
                {
                    return _radioButton.Value;
                }
            }
            // private to prevent direct instantiation.
            private RegexUtility()
            {
            }
            // accessor for instance
            public static RegexUtility Instance
            {
                get
                {
                    return _instance.Value;
                }
            }
        }

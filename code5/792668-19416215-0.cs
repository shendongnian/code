    using System;
    class Foo
    {
        private readonly Lazy<string> _str;
        public Foo()
        {
            _str = new Lazy<string>(GetString);
        }
        private string TheString
        {
            get
            {
                return _str.Value;
            }
        }
        private string GetString()
        {
            return "blah";
        }
    }

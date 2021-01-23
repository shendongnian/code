    public class Foo
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public static implicit operator string(Foo foo)
        {
            return foo == null ? string.Empty : foo.Value;
        }
        public override string ToString()
        {
            var str = string.Empty;
            if (!string.IsNullOrEmpty(Key))
            {
                if (str.Length > 0)
                    str += ";";
                str += ("Key=" + Key);
            }
            if (!string.IsNullOrEmpty(Value))
            {
                if (str.Length > 0)
                    str += ";";
                str += ("Value=" + Value);
            }
            return str;
        }
    }

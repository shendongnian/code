            var sp = new Parser("# (d+) VO(d+) SP(d+)\\+");
            int a, b, c;
            bool ok = sp.Parse<int, int, int>("# 123 VO256 SP256+", out a, out b, out c);
.
    /// <summary>
    /// A strongly typed parse result containing up to 10 elements, each individually strongly typed
    /// </summary>
    public class Parser
    {
        Regex regex;
        public Parser(string regularExpression)
        {
            this.regex = new Regex(regularExpression, RegexOptions.Compiled);
        }
        public bool Parse<T>(string input, out T value1)
        {
            bool ok = true;
            var match = this.regex.Match(input);
            ok = Assign(match, 1, out value1) && ok;
            return ok;
        }
        public bool Parse<T1, T2>(string input, out T1 value1, out T2 value2)
        {
            bool ok = true;
            var match = this.regex.Match(input);
            ok = Assign(match, 1, out value1) && ok;
            ok = Assign(match, 2, out value2) && ok;
            return ok;
        }
        public bool Parse<T1, T2, T3>(string input, out T1 value1, out T2 value2, out T3 value3)
        {
            bool ok = true;
            var match = this.regex.Match(input);
            ok = Assign(match, 1, out value1) && ok;
            ok = Assign(match, 2, out value2) && ok;
            ok = Assign(match, 3, out value3) && ok;
            return ok;
        }
        public bool Parse<T1, T2, T3, T4>(string input, out T1 value1, out T2 value2, out T3 value3, out T4 value4)
        {
            bool ok = true;
            var match = this.regex.Match(input);
            ok = Assign(match, 1, out value1) && ok;
            ok = Assign(match, 2, out value2) && ok;
            ok = Assign(match, 3, out value3) && ok;
            ok = Assign(match, 4, out value4) && ok;
            return ok;
        }
        public bool Parse<T1, T2, T3, T4, T5>(string input, out T1 value1, out T2 value2, out T3 value3, out T4 value4, out T5 value5)
        {
            bool ok = true;
            var match = this.regex.Match(input);
            ok = Assign(match, 1, out value1) && ok;
            ok = Assign(match, 2, out value2) && ok;
            ok = Assign(match, 3, out value3) && ok;
            ok = Assign(match, 4, out value4) && ok;
            ok = Assign(match, 5, out value5) && ok;
            return ok;
        }
        public bool Parse<T1, T2, T3, T4, T5, T6>(string input, out T1 value1, out T2 value2, out T3 value3, out T4 value4, out T5 value5, out T6 value6)
        {
            bool ok = true;
            var match = this.regex.Match(input);
            ok = Assign(match, 1, out value1) && ok;
            ok = Assign(match, 2, out value2) && ok;
            ok = Assign(match, 3, out value3) && ok;
            ok = Assign(match, 4, out value4) && ok;
            ok = Assign(match, 5, out value5) && ok;
            ok = Assign(match, 6, out value6) && ok;
            return ok;
        }
        public bool Parse<T1, T2, T3, T4, T5, T6, T7>(string input, out T1 value1, out T2 value2, out T3 value3, out T4 value4, out T5 value5, out T6 value6, out T7 value7)
        {
            bool ok = true;
            var match = this.regex.Match(input);
            ok = Assign(match, 1, out value1) && ok;
            ok = Assign(match, 2, out value2) && ok;
            ok = Assign(match, 3, out value3) && ok;
            ok = Assign(match, 4, out value4) && ok;
            ok = Assign(match, 5, out value5) && ok;
            ok = Assign(match, 6, out value6) && ok;
            ok = Assign(match, 7, out value7) && ok;
            return ok;
        }
        public bool Parse<T1, T2, T3, T4, T5, T6, T7, T8>(string input, out T1 value1, out T2 value2, out T3 value3, out T4 value4, out T5 value5, out T6 value6, out T7 value7, out T8 value8)
        {
            bool ok = true;
            var match = this.regex.Match(input);
            ok = Assign(match, 1, out value1) && ok;
            ok = Assign(match, 2, out value2) && ok;
            ok = Assign(match, 3, out value3) && ok;
            ok = Assign(match, 4, out value4) && ok;
            ok = Assign(match, 5, out value5) && ok;
            ok = Assign(match, 6, out value6) && ok;
            ok = Assign(match, 7, out value7) && ok;
            ok = Assign(match, 8, out value8) && ok;
            return ok;
        }
        public bool Parse<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string input, out T1 value1, out T2 value2, out T3 value3, out T4 value4, out T5 value5, out T6 value6, out T7 value7, out T8 value8, out T9 value9)
        {
            bool ok = true;
            var match = this.regex.Match(input);
            ok = Assign(match, 1, out value1) && ok;
            ok = Assign(match, 2, out value2) && ok;
            ok = Assign(match, 3, out value3) && ok;
            ok = Assign(match, 4, out value4) && ok;
            ok = Assign(match, 5, out value5) && ok;
            ok = Assign(match, 6, out value6) && ok;
            ok = Assign(match, 7, out value7) && ok;
            ok = Assign(match, 8, out value8) && ok;
            ok = Assign(match, 9, out value9) && ok;
            return ok;
        }
        public bool Parse<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string input, out T1 value1, out T2 value2, out T3 value3, out T4 value4, out T5 value5, out T6 value6, out T7 value7, out T8 value8, out T9 value9, out T10 value10)
        {
            bool ok = true;
            var match = this.regex.Match(input);
            ok = Assign(match, 1, out value1) && ok;
            ok = Assign(match, 2, out value2) && ok;
            ok = Assign(match, 3, out value3) && ok;
            ok = Assign(match, 4, out value4) && ok;
            ok = Assign(match, 5, out value5) && ok;
            ok = Assign(match, 6, out value6) && ok;
            ok = Assign(match, 7, out value7) && ok;
            ok = Assign(match, 8, out value8) && ok;
            ok = Assign(match, 9, out value9) && ok;
            ok = Assign(match, 10, out value10) && ok;
            return ok;
        }
        private bool Assign<X>(Match match, int index, out X value)
        {
            if (match.Success)
            {
                Group group = match.Groups[index];
                var stringValue = group.Value;
                var foo = TypeDescriptor.GetConverter(typeof(X));
                value = (X)(foo.ConvertFromInvariantString(stringValue));
                return true;
            }
            else
            {
                value = default(X);
                return false;
            }
        }

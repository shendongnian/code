    public interface IParser {
        object Parse(string s);
    }
    public class BoolParser : IParser {
        public object Parse(string s) {
            return bool.Parse(s);
        }
    }
    public class IntParser : IParser {
        public object Parse(string s) {
            return int.Parse(s);
        }
    }

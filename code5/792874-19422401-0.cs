    public static class ParameterGuard
    {
        public static void ThrowIfNullOrEmpty<T>(IEnumerable<T> enumerable, string argName)
        {
            if (enumerable == null)
                throw new ArgumentNullException(argName);
            if (!enumerable.Any())
                throw new ArgumentException();
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            list.Add("test");
            ParameterGuard.ThrowIfNullOrEmpty(list, "list");
            ParameterGuard.ThrowIfNullOrEmpty("string", "str");
        }
    }

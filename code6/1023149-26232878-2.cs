    public interface IOne { }
    public interface ITwo { }
    public static class Extensions
    {
        public static string ParseValue(this ITwo ob)
        {
            return "Two";
        }
        public static string ParseValue<T>(this T obj) where T : class, ITwo
        {
            return "One";
        }
    }
    public class Two : ITwo
    {
        public string Test()
        {
            return this.ParseValue();
        }
    }

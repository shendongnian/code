    /// <summary> Enum Extension Methods </summary>
    /// <typeparam name="T"> type of Enum </typeparam>
    public class Enum<T> where T : struct, IConvertible
    {
        public static T Parse(string input)
        {
            return (T)Enum.Parse(typeof(T), input, true);
        }
    }

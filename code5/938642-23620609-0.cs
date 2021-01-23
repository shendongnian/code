    public sealed class Aa
    {
        public void Close()
        {
        }
    }
    public interface IClosable
    {
        void Close();
    }
    internal class AbcClosable : IClosable
    {
        private readonly Aa _aa;
        public AbcClosable(Aa aa)
        {
            _aa = aa;
        }
        public void Close()
        {
            _aa.Close();
        }
    }
    public static class CloseableExtensions
    {
        public static void CloseThis<T>(this T value)
            where T : IClosable
        {
            value.Close();
        }
    }

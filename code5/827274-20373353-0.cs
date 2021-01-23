    public class Coin { }
    public class Coin50 : Coin { }
    public class Coin25 : Coin { }
    /* End given condition */
    public interface ICoinStack
    {
        T Pop<T>() where T: Coin;
        void Push<T>(T item) where T: Coin;
    }
    /* The problem within this abstract class */
    public abstract class CoinStack : ICoinStack
    {
        private Queue<Coin> _stack = new Queue<Coin>();
        public TCoin Pop<TCoin>() where TCoin: Coin { return (TCoin)_stack.Dequeue(); }
        public void Push<TCoin>(TCoin item) where TCoin: Coin { _stack.Enqueue(item); }
    }
    public class CoinStack50 : CoinStack { }
    public class CoinStack25 : CoinStack { }
    public class CoinMachine
    {
        private static Dictionary<Type, ICoinStack> map;
        static CoinMachine()
        {
            map = new Dictionary<Type, ICoinStack>()
            {
                { typeof(Coin50), new CoinStack50() },
                { typeof(Coin25), new CoinStack25() }
            };
        }
        public static T Pop<T>() where T: Coin
        {
            var type = typeof(T);
            return map[type].Pop<T>();
        }
        public static void Push<T>(T item) where T: Coin
        {
            var type = typeof(T);
            map[type].Push(item);
        }
    }

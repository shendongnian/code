    public interface ICoinStack
    {
       Coin Pop();
       void Push(Coin item);
    }
    
    public abstract class CoinStack<T> : ICoinStack where T:Coin
    {
       private Queue<T> _stack = new Queue<T>();
    
       Coin ICoinStack.Pop() { return _stack.Dequeue(); }
       void ICoinStack.Push(Coin item) { _stack.Enqueue((T)item); }
    
       public T Pop() { return _stack.Dequeue(); }
       public void Push(T item) { _stack.Enqueue(item); }
    }
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
    
       public static T Pop<T>() where T:Coin
       {
           var type = typeof(T);
           return (T)map[type].Pop();
       }
    
       public static void Push<T>(T item) where T:Coin
       {
           var type = typeof(T);
           map[type].Push(item);
       }
    }

    public static void Square(int x, Action<int> callback)
    {
    callback(x * x);
    }
3. Curry the Callback
 
    public static Action<Action<int>> Square(int x)
    {
     return (callback) => { callback(x * x); };
    }
4. Generalize the returned Continuation
    public static Func<Func<int,T>,T> Square<T>(int x)
    {
         return (callback) => { callback(x * x); };
    }
5. Extract the Continuation Structure Also Known As the Return Method of the monad. That is Give me a value and i will give you a Monad for this value
    //((U→ T) → T)
       delegate T Cont<U, T>(Func<U, T> f);
    public static Cont<U, T> ToContinuation<U, T>(this U x)
    {
       return (callback) => callback(x);
    }
    square.ToContinuation<Func<int, int>, int>()
6. Add The bind Monadic method and thus Complete the Monad.That is Give me a Two Monads and i will combine them to a new monad
((A→ T) → T)→( A→((B→ T) → T))→ ((B→ T) → T)
    public static Cont<V, Answer> Bind<T, U, V, Answer>(
    this Cont<T, Answer> m,
    Func<T, Cont<U, Answer>> k, 
    Func<T, U, V> selector)
    {
     return (Func<V, Answer> c) => 
    m(t => k(t)(y => c(selector(t, y))));
    }
  [1]: https://medium.com/@dimpapadim3/deriving-continuation-monad-from-callbacks-23d74e8331d0
  [2]: https://dotnetfiddle.net/yP02m0

    void Main()
    {
        Func<bool,bool> f = i => {SomeAction();return true;};
        Console.WriteLine(SomeMethod(f));
    }
    public T SomeMethod<T>( Func<T, T> f ) 
    {
        return f(default(T));
    }
    public void SomeAction()
    {
        Console.WriteLine("called");
    }

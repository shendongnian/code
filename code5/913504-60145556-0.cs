C#
public TResult Foo<TResult> (Func<TResult> f)
{
    return f();
}
public TResult Foo<T1, TResult>(Func<T1, TResult> f, T1 t1)
{
    return f(t1);
}
public TResult Foo<T1, T2, TResult>(Func<T1, T2, TResult> f, T1 t1, T2 t2)
{
    return f(t1, t2);
}
...

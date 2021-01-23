class C
{
    public T1Binder&lt;T1&gt; M1&lt;T1&gt;(...) {}
}
class T1Binder&lt;T1&gt;
{
    public T2Binder&lt;T2&gt; M2&lt;T2&gt;(...) {}
}
...
class TFinalBinder&lt;T(n - 1)&gt;
{
    public void MFinal&lt;Tn&gt;(...) {}
}

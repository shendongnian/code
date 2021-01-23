    public void Test()
    {
        TestFoo();
    }
    private Foo _foo;
    private void TestFoo(Foo foo = null)
    {
        _foo = foo ?? new Foo();
    }
    public class Foo
    {
    }

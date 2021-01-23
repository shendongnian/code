    public void SomeTestMethod()
    {
        // before any state has change.
        using (Setup())
        {
              // Test code.
        }
        // the cleanup code has run so the state is reset here.
    }
    private static IDisposable Setup()
    {
        return new DisposableList() {
            ValueHolder.Create(() => Notify.DoNotify, false),
            ValueHolder.Create(() => ConnectionManager.MaxConnections, 100),
            ValueHolder.Create(() => SomeClass.SomeProp, 2.5),
            // etc., I think you get the idea.
        };
    }

    var FooUpdater = new PeriodicUpdater(
        FooUpdateAction, 
        TimeSpan.FromSeconds(2.0),
        TimeSpan.FromSeconds(8.0));
    var BarUpdater = new PeriodicUpdater(
        BarUpdateAction,
        TimeSpan.FromSeconds(10.0),
        TimeSpan.FromSeconds(15.5));
    private void FooUpdateAction()
    {
        // do the Foo update
    }
    private void BarUpdateAction()
    {
        // do the Bar update
    }

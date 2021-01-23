    protected async void DoStuffAsync()
    {
        SomeThing thing = new SomeThing { ID = 5 };
        SomeRepository rep = new SomeRepository();
        var handleRed = GetAndSaveRedAsync(thing, rep);
        var handleBlue = GetAndSaveBlueAsync(thing, rep);
        var handleYellow = GetAndSaveYellowAsync(thing, rep);
        // Or use Task.WhenAll
        await handleRed;
        await handleBlue;
        await handleYellow;
    }

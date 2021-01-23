    public async Task<ActionResult> MyActionAsync()
    {
        var asdf = SharedTypes.Utilities.GetjsonStream(someUrl);
        string g = await asdf;
        // return something
    }

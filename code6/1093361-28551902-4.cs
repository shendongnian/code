    public void Populate(IEnumerable<OtherThings> things)
    {
        var temp = new List<DisposableObject>();
        try
        {
            temp.AddRange(things.Select(otherThing => new DisposableObject(otherThing)));
            items = temp;
        }
        catch
        {
            foreach (var disposableObject in temp)
            {
                disposableObject.Dispose();
            }
            throw;
        }
    }

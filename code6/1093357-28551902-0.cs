    public void Populate(IEnumerable<OtherThings> things)
    {
        var temp = new List<DisposableObject>();
        try
        {
            foreach (var otherThing in things)
            {
                temp.Add(new DisposableObject(otherThing));
            }
            items = temp;
        }
        finally
        {
            foreach (var disposableObject in temp)
            {
                disposableObject.Dispose();
            }
        }
    }

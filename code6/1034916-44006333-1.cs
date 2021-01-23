    var enumerator = FormFields.GetEnumerator();
    try
    {
        while (enumerator.MoveNext())
        {
            CDatabaseField item = (CDatabaseField)enumerator.Current;
        }
    }
    finally
    {
        var disposable = enumerator as IDisposable;
        disposable?.Dispose();
    }

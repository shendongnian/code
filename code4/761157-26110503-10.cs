    List<int>.Enumerator enumerator = valueList.GetEnumerator();
    try {
        while (enumerator.MoveNext()) {
            int value = enumerator.Current;
            // do something with value
        }
    }
    finally {
        IDisposable disposable = enumerator as System.IDisposable;
        if (disposable != null) disposable.Dispose();
    }

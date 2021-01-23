    var e = GetSomeEnumerable().GetEnumerator();
    try{
        while(e.MoveNext()){
            T t = (T)e.Current; // unless e is the generic IEnumerable<T>,
                                // in which case, there is no cast
            DoSomethingWithT(t);
        }
    }finally{
        if(e is IDisposable)
            e.Dispose();
    }

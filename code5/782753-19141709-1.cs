    void Func(IEnumerable<T> e)
    {
        Type t;
        if(e.Count() > 0){
            t = e.ElementAt(0).GetType();
        }
    }

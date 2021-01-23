    public T MyMethod<T>()
    {
        T resultAsT = some function ....
        var resultAsI = (resultAsT as I);
        if (resultAsI != null)
        {
            resultAsI.PropertyOnlyAvailableInI = 99;
        }
        return resultAsT;
    }

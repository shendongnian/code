    TData Add<TData>(TData data) where TData:Data
    {
        var infoBase = data as InfoBase; //or IRelated as in my earlier samples
        TData result;
        if (infoBase != null)
        {
            result = Get(data.id, infoBase.Related[0].Id); //you can also use infoBase.Id as first param
        }
        else
        {
            result = Get(data.id, null); //whatever you need to pass to the method if there is no related item
        }
    }

     public object MyMethod()
         {
             object resultAsT = something;
        var resultAsI = (resultAsT as ISomething);
        if (resultAsI != null)
        {
            resultAsI.PropertyOnlyAvailableInI = 99;
            return resultAsI;
        }
        else
            return resultAsT;
    }

    if((object)x == null && (object)y == null)
    {
        return true;
    }
    return  !((object)x == null) && !((object)y == null)
            && x.GetType() == y.GetType()
            && x.GetType()
                .GetProperties()
                .All(property => property.GetValue(x) == property.GetValue(y));

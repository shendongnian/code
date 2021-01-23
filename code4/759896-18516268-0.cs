    void string CorrectParam(string param)
    {
        if (param == null)
            return "default";
        return param;
    }
    void TAXCheckControlNumberForAccuracy(string City, string Zip, string State, string Owner)
    {
    }
    //call using this
    TAXCheckControlNumberForAccuracy(CorrectParam(City), CorrectParam(Zip), CorrectParam(State), CorrectParam(Owner));

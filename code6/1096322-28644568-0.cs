    public override object GetParam(string supportedParam)
    {
        ...
    }
    dynamic derivedOneParam = derivedOne.GetParam(supportedParam);
    Console.WriteLine(derivedOneParam.Value);

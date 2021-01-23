    IType decimalType = TypeFactory.Basic("Decimal(19,10)");
    
    IQuery query = Session.CreateSQLQuery("....");
    query.SetParameter("rate", exchangeRate.Rate, decimalType);
    query.SetInt32("otherParamter", otherParamter);
    query.ExecuteUpdate();

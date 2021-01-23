    int? contrPrice = objco.calculateContractPrice(coid);
    if(contrPrice == null)
    {
       // error handling
    }
    else
    {
        objco.Tax = (int)(contrPrice * ((double)6 / 100));
    }

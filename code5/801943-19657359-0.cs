    var availableCodes = 
        Enum.GetValues(typeof(ProductCodeType))
            .Except((int)ProductCodeType.None)
            .Except(productCodes.Select( p => p.Id)
            .Select(p => new {
                                  Id = p;
                                  Name = ((ProductCodeType)p).ToString();
                             }   

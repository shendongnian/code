    UserDefinedConversionResult? exactConversionResult = null;
    foreach (UserDefinedConversionAnalysis analysis in u)
    {
        TypeSymbol tx = analysis.ToType;
        if (tx.IsValidSwitchGoverningType(isTargetTypeOfUserDefinedOp: true))
        {
            if (!exactConversionResult.HasValue)
            {
                exactConversionResult = UserDefinedConversionResult.Valid(u, best.Value);
                continue;
            }
 
            return UserDefinedConversionResult.Ambiguous(u);
        }
    }
 
    // If there exists such unique TX in suitableTypes, then that operator is the  
    // resultant user defined conversion and TX is the resultant switch governing type.
    // Otherwise we either have ambiguity or no applicable operators.
    return exactConversionResult.HasValue ?
        exactConversionResult.Value :
        UserDefinedConversionResult.NoApplicableOperators(u);

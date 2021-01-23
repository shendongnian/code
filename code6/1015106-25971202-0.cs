    interface IEnumerableSignatures
    {
        bool Contains(object selector); // Add this
        void Where(bool predicate);
        //...
    // Then around line 628 add a new keyword:
    
    static readonly string keywordOuterIt = "outerIt";
    static readonly string keywordIt = "It";
    //...
    // above ParameterExpression It; add
    ParameterExpression outerIt;
    
    // In ParseIdentifier add
    if (value == (object)keywordOuterIt) return ParseOuterIt();
    
    //Then add that method
    Expression ParseOuterIt()
    {
        if (outerIt == null)
            throw ParseError(Res.NoItInScope);
        NextToken();
        return outerIt;
    }
    
    // In ParseAggreggate, add:
    outerIt = it;
    
    if (signature.Name == "Min" || signature.Name == "Max")
    {
        typeArgs = new Type[] { elementType, args[0].Type };
    }
    else
    {
        typeArgs = new Type[] { elementType };
    }
    if (args.Length == 0)
    {
        args = new Expression[] { instance };
    }
    else
    {	
        // add this section
        if (signature.Name == "Contains")
            args = new Expression[] { instance, args[0] };
        else
        {
            args = new Expression[] { instance, Expression.Lambda(args[0], innerIt) };
        }
    }
    
    // In CreateKeyWords()
    
    d.Add(keywordOuterIt, keywordOuterIt); // Add this

    Expression<Func<int, bool>> e1 = i => true;
    Expression<Func<int, bool>> e2 = j => false;
    
    Console.WriteLine(e1.Parameters[0] == e2.Parameters[0]); // false
   
    var replacements = new Dictionary<ParameterExpression, ParameterExpression>
    {
        { e1.Parameters[0], e2.Parameters[0] }
    };
    var replacer = new ParameterReplacementVisitor(replacements);
    var e3 = replacer.VisitAndConvert(e1, "replacing parameters");
    
    Console.WriteLine(e3.Parameters[0] == e2.Parameters[0]); // true

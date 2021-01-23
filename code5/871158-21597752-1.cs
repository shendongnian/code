    object result = ExpressionEvaluator.GetValue(null, "A.A_S1");
    Assert.AreEqual(A.A_S1, result);
    
    result = ExpressionEvaluator.GetValue(null, "A.B.AB_S1");
    Assert.AreEqual(A.B.AB_S1, result);

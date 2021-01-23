    IL_0000:  nop         
    IL_0001:  ldstr       ""
    IL_0006:  ldtoken     System.String
    IL_000B:  call        System.Type.GetTypeFromHandle
    IL_0010:  call        System.Linq.Expressions.Expression.Constant
    IL_0015:  ldc.i4.0    
    IL_0016:  newarr      System.Linq.Expressions.ParameterExpression
    IL_001B:  call        System.Linq.Expressions.Expression.Lambda
    IL_0020:  stloc.0     // foo
    IL_0021:  ret    

    IL_0001:  ldarg.0     
    IL_0002:  stloc.0     // db
    IL_0003:  ldloc.0     // db
    IL_0004:  callvirt    LINQPad.User.TypedDataContext.get_TblEmployees
    IL_0009:  ldtoken     LINQPad.User.TblEmployees
    IL_000E:  call        System.Type.GetTypeFromHandle
    IL_0013:  ldstr       "t"
    IL_0018:  call        System.Linq.Expressions.Expression.Parameter
    IL_001D:  stloc.1     // CS$0$0000
    IL_001E:  ldloc.1     // CS$0$0000
    IL_001F:  ldtoken     LINQPad.User.TblEmployees.get_Age
    IL_0024:  call        System.Reflection.MethodBase.GetMethodFromHandle
    IL_0029:  castclass   System.Reflection.MethodInfo
    IL_002E:  call        System.Linq.Expressions.Expression.Property
    IL_0033:  ldc.i4.s    1E 
    IL_0035:  box         System.Int32
    IL_003A:  ldtoken     System.Int32
    IL_003F:  call        System.Type.GetTypeFromHandle
    IL_0044:  call        System.Linq.Expressions.Expression.Constant
    IL_0049:  ldtoken     System.Nullable<System.Int32>
    IL_004E:  call        System.Type.GetTypeFromHandle
    IL_0053:  call        System.Linq.Expressions.Expression.Convert
    IL_0058:  call        System.Linq.Expressions.Expression.GreaterThan
    IL_005D:  ldc.i4.1    
    IL_005E:  newarr      System.Linq.Expressions.ParameterExpression
    IL_0063:  stloc.2     // CS$0$0001
    IL_0064:  ldloc.2     // CS$0$0001
    IL_0065:  ldc.i4.0    
    IL_0066:  ldloc.1     // CS$0$0000
    IL_0067:  stelem.ref  
    IL_0068:  ldloc.2     // CS$0$0001
    IL_0069:  call        System.Linq.Expressions.Expression.Lambda
    IL_006E:  call        System.Linq.Queryable.Count

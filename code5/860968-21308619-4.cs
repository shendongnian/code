    // ToList<int>
    IL_0001:  ldtoken     System.Collections.Generic.IEnumerable<System.Int32>
    IL_0006:  call        System.Type.GetTypeFromHandle
    IL_000B:  ldstr       "ToList"
    IL_0010:  ldc.i4.1    
    IL_0011:  newarr      System.Type
    IL_0016:  stloc.3     // CS$0$0000
    IL_0017:  ldloc.3     // CS$0$0000
    IL_0018:  ldc.i4.0    
    IL_0019:  ldtoken     System.Collections.Generic.IEnumerable<System.Int32>
    IL_001E:  call        System.Type.GetTypeFromHandle
    IL_0023:  stelem.ref  
    IL_0024:  ldloc.3     // CS$0$0000
    IL_0025:  call        System.Reflection.RuntimeReflectionExtensions.GetRuntimeMethod
    IL_002A:  stloc.0     // _intToListMethod
    // ToList<>
    IL_002B:  ldtoken     System.Linq.Enumerable
    IL_0030:  call        System.Type.GetTypeFromHandle
    IL_0035:  ldstr       "ToList"
    IL_003A:  ldc.i4.1    
    IL_003B:  newarr      System.Type
    IL_0040:  stloc.3     // CS$0$0000
    IL_0041:  ldloc.3     // CS$0$0000
    IL_0042:  ldc.i4.0    
    IL_0043:  ldtoken     System.Collections.Generic.IEnumerable<>
    IL_0048:  call        System.Type.GetTypeFromHandle
    IL_004D:  stelem.ref  
    IL_004E:  ldloc.3     // CS$0$0000
    IL_004F:  call        System.Reflection.RuntimeReflectionExtensions.GetRuntimeMethod
    IL_0054:  stloc.1     // _toListMethod
    // Cast<>
    IL_0055:  ldtoken     System.Linq.Enumerable
    IL_005A:  call        System.Type.GetTypeFromHandle
    IL_005F:  ldstr       "Cast"
    IL_0064:  ldc.i4.1    
    IL_0065:  newarr      System.Type
    IL_006A:  stloc.3     // CS$0$0000
    IL_006B:  ldloc.3     // CS$0$0000
    IL_006C:  ldc.i4.0    
    IL_006D:  ldtoken     System.Collections.Generic.IEnumerable<>
    IL_0072:  call        System.Type.GetTypeFromHandle
    IL_0077:  stelem.ref  
    IL_0078:  ldloc.3     // CS$0$0000
    IL_0079:  call        System.Reflection.RuntimeReflectionExtensions.GetRuntimeMethod
    IL_007E:  stloc.2     // _castMethod

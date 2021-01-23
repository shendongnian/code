    IL_0000:  newobj      System.Collections.Generic.List<System.Object>..ctor
    IL_0005:  stloc.0     // myCollection
    IL_0006:  ldloc.0     // myCollection
    IL_0007:  ldc.i4.1    
    IL_0008:  call        System.Linq.Enumerable.Skip <-- 1 Call to .Skip()
    IL_000D:  pop         
    IL_000E:  ldloc.0     // myCollection
    IL_000F:  callvirt    System.Collections.Generic.List<System.Object>.GetEnumerator
    IL_0014:  stloc.2     // CS$5$0000
    IL_0015:  br.s        IL_002A
    IL_0017:  ldloca.s    02 // CS$5$0000
    IL_0019:  call        System.Collections.Generic.List<System.Object>+Enumerator.get_Current
    IL_001E:  stloc.1     // i
    IL_001F:  ldloc.1     // i
    IL_0020:  callvirt    System.Object.ToString
    IL_0025:  call        System.Console.WriteLine
    IL_002A:  ldloca.s    02 // CS$5$0000
    IL_002C:  call        System.Collections.Generic.List<System.Object>+Enumerator.MoveNext
    IL_0031:  brtrue.s    IL_0017
    IL_0033:  leave.s     IL_0043
    IL_0035:  ldloca.s    02 // CS$5$0000
    IL_0037:  constrained. System.Collections.Generic.List<>.Enumerator
    IL_003D:  callvirt    System.IDisposable.Dispose
    IL_0042:  endfinally  

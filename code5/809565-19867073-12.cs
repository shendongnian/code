    IL_0000:  newobj      System.Collections.Generic.List<System.Object>..ctor
    IL_0005:  stloc.0     // myCollection
    IL_0006:  ldloc.0     // myCollection
    IL_0007:  ldc.i4.1    
    IL_0008:  call        System.Linq.Enumerable.Skip
    IL_000D:  stloc.1     // skipped
    IL_000E:  ldloc.1     // skipped
    IL_000F:  callvirt    System.Collections.Generic.IEnumerable<System.Object>.GetEnumerator
    IL_0014:  stloc.3     // CS$5$0000
    IL_0015:  br.s        IL_0029
    IL_0017:  ldloc.3     // CS$5$0000
    IL_0018:  callvirt    System.Collections.Generic.IEnumerator<System.Object>.get_Current
    IL_001D:  stloc.2     // i
    IL_001E:  ldloc.2     // i
    IL_001F:  callvirt    System.Object.ToString
    IL_0024:  call        System.Console.WriteLine
    IL_0029:  ldloc.3     // CS$5$0000
    IL_002A:  callvirt    System.Collections.IEnumerator.MoveNext
    IL_002F:  brtrue.s    IL_0017
    IL_0031:  leave.s     IL_003D
    IL_0033:  ldloc.3     // CS$5$0000
    IL_0034:  brfalse.s   IL_003C
    IL_0036:  ldloc.3     // CS$5$0000
    IL_0037:  callvirt    System.IDisposable.Dispose
    IL_003C:  endfinally  

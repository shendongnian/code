    var myCollection = new List<object>();
	
    foreach (var i in myCollection.Skip(1)) {
	Console.WriteLine(i.ToString());
    }
    IL_0000:  newobj      System.Collections.Generic.List<System.Object>..ctor
    IL_0005:  stloc.0     // myCollection
    IL_0006:  ldloc.0     // myCollection
    IL_0007:  ldc.i4.1    
    IL_0008:  call        System.Linq.Enumerable.Skip <-- 1 Call to .Skip()
    IL_000D:  callvirt    System.Collections.Generic.IEnumerable<System.Object>.GetEnumerator
    IL_0012:  stloc.2     // CS$5$0000
    IL_0013:  br.s        IL_0027
    IL_0015:  ldloc.2     // CS$5$0000
    IL_0016:  callvirt    System.Collections.Generic.IEnumerator<System.Object>.get_Current
    IL_001B:  stloc.1     // i
    IL_001C:  ldloc.1     // i
    IL_001D:  callvirt    System.Object.ToString
    IL_0022:  call        System.Console.WriteLine
    IL_0027:  ldloc.2     // CS$5$0000
    IL_0028:  callvirt    System.Collections.IEnumerator.MoveNext
    IL_002D:  brtrue.s    IL_0015
    IL_002F:  leave.s     IL_003B
    IL_0031:  ldloc.2     // CS$5$0000
    IL_0032:  brfalse.s   IL_003A
    IL_0034:  ldloc.2     // CS$5$0000
    IL_0035:  callvirt    System.IDisposable.Dispose
    IL_003A:  endfinally  

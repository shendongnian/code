    callvirt    System.Collections.Generic.List<System.Int32>.GetEnumerator
    stloc.s     04 // CS$5$0000
    br.s        IL_0030
    ldloca.s    04 // CS$5$0000
    call        System.Collections.Generic.List<System.Int32>+Enumerator.get_Current
    stloc.3     // number
    nop         
    nop         
    ldloca.s    04 // CS$5$0000
    call        System.Collections.Generic.List<System.Int32>+Enumerator.MoveNext
    stloc.s     05 // CS$4$0001
    ldloc.s     05 // CS$4$0001
    brtrue.s    IL_0026
    leave.s     IL_004E
    ldloca.s    04 // CS$5$0000
    constrained. System.Collections.Generic.List<>.Enumerator
    callvirt    System.IDisposable.Dispose
    nop         
    endfinally  

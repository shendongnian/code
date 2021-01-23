    .method private hidebysig static void V1(class [mscorlib]System.Collections.Generic.Dictionary`2<string, string> myCollection) cil managed
    {
        .maxstack 2
        .locals init (
            [0] string uniqueItem,
            [1] class [mscorlib]System.Collections.Generic.IEnumerator`1<string> CS$5$0000,
            [2] bool CS$4$0001)
        L_0000: nop 
        L_0001: nop 
        L_0002: ldarg.0 
        L_0003: callvirt instance class [mscorlib]System.Collections.Generic.Dictionary`2/ValueCollection<!0, !1> [mscorlib]System.Collections.Generic.Dictionary`2<string, string>::get_Values()
        L_0008: call class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0> [System.Core]System.Linq.Enumerable::Distinct<string>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>)
        L_000d: callvirt instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> [mscorlib]System.Collections.Generic.IEnumerable`1<string>::GetEnumerator()
        L_0012: stloc.1 
        L_0013: br.s L_001e
        L_0015: ldloc.1 
        L_0016: callvirt instance !0 [mscorlib]System.Collections.Generic.IEnumerator`1<string>::get_Current()
        L_001b: stloc.0 
        L_001c: nop 
        L_001d: nop 
        L_001e: ldloc.1 
        L_001f: callvirt instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
        L_0024: stloc.2 
        L_0025: ldloc.2 
        L_0026: brtrue.s L_0015
        L_0028: leave.s L_003a
        L_002a: ldloc.1 
        L_002b: ldnull 
        L_002c: ceq 
        L_002e: stloc.2 
        L_002f: ldloc.2 
        L_0030: brtrue.s L_0039
        L_0032: ldloc.1 
        L_0033: callvirt instance void [mscorlib]System.IDisposable::Dispose()
        L_0038: nop 
        L_0039: endfinally 
        L_003a: nop 
        L_003b: ret 
        .try L_0013 to L_002a finally handler L_002a to L_003a
    }

      .method private hidebysig static class [mscorlib]System.Collections.Generic.IEnumerable`1<string> ProductNames(class [mscorlib]System.Collections.Generic.IEnumerable`1<class ConsoleApplication3.Product> products) cil managed
    {
        .maxstack 3
        .locals init (
            [0] class [mscorlib]System.Collections.Generic.IEnumerable`1<string> enumerable,
            [1] class [mscorlib]System.Collections.Generic.IEnumerable`1<string> enumerable2)
        L_0000: nop 
        L_0001: ldarg.0 
        L_0002: ldsfld class [mscorlib]System.Func`2<class ConsoleApplication3.Product, bool> ConsoleApplication3.Program::CS$<>9__CachedAnonymousMethodDelegate3
        L_0007: dup 
        L_0008: brtrue.s L_001d
        L_000a: pop 
        L_000b: ldnull 
        L_000c: ldftn bool ConsoleApplication3.Program::<ProductNames>b__2(class ConsoleApplication3.Product)
        L_0012: newobj instance void [mscorlib]System.Func`2<class ConsoleApplication3.Product, bool>::.ctor(object, native int)
        L_0017: dup 
        L_0018: stsfld class [mscorlib]System.Func`2<class ConsoleApplication3.Product, bool> ConsoleApplication3.Program::CS$<>9__CachedAnonymousMethodDelegate3
        L_001d: call class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0> [System.Core]System.Linq.Enumerable::Where<class ConsoleApplication3.Product>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>, class [mscorlib]System.Func`2<!!0, bool>)
        L_0022: ldsfld class [mscorlib]System.Func`2<class ConsoleApplication3.Product, string> ConsoleApplication3.Program::CS$<>9__CachedAnonymousMethodDelegate5
        L_0027: dup 
        L_0028: brtrue.s L_003d
        L_002a: pop 
        L_002b: ldnull 
        L_002c: ldftn string ConsoleApplication3.Program::<ProductNames>b__4(class ConsoleApplication3.Product)
        L_0032: newobj instance void [mscorlib]System.Func`2<class ConsoleApplication3.Product, string>::.ctor(object, native int)
        L_0037: dup 
        L_0038: stsfld class [mscorlib]System.Func`2<class ConsoleApplication3.Product, string> ConsoleApplication3.Program::CS$<>9__CachedAnonymousMethodDelegate5
        L_003d: call class [mscorlib]System.Collections.Generic.IEnumerable`1<!!1> [System.Core]System.Linq.Enumerable::Select<class ConsoleApplication3.Product, string>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>, class [mscorlib]System.Func`2<!!0, !!1>)
        L_0042: stloc.0 
        L_0043: ldloc.0 
        L_0044: stloc.1 
        L_0045: br.s L_0047
        L_0047: ldloc.1 
        L_0048: ret 
    }

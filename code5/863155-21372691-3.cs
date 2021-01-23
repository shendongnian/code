    .method public hidebysig specialname 
    	instance class [mscorlib]System.Collections.Generic.List`1<valuetype Program/GroupByDateType> get_GroupByItems () cil managed 
    {
    	// Method begins at RVA 0x2070
    	// Code size 45 (0x2d)
    	.maxstack 3
    	.locals init (
    		[0] class [mscorlib]System.Collections.Generic.List`1<valuetype Program/GroupByDateType> CS$0$0000
    	)
    
    	IL_0000: ldarg.0
    	IL_0001: ldfld class [mscorlib]System.Collections.Generic.List`1<valuetype Program/GroupByDateType> Program::_GroupByItems
    	IL_0006: dup
    	IL_0007: brtrue.s IL_002c
    
    	IL_0009: pop
    	IL_000a: ldarg.0
    	IL_000b: ldtoken Program/GroupByDateType
    	IL_0010: call class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
    	IL_0015: call class [mscorlib]System.Array [mscorlib]System.Enum::GetValues(class [mscorlib]System.Type)
    	IL_001a: call class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0> [System.Core]System.Linq.Enumerable::Cast<valuetype Program/GroupByDateType>(class [mscorlib]System.Collections.IEnumerable)
    	IL_001f: call class [mscorlib]System.Collections.Generic.List`1<!!0> [System.Core]System.Linq.Enumerable::ToList<valuetype Program/GroupByDateType>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>)
    	IL_0024: dup
    	IL_0025: stloc.0
    	IL_0026: stfld class [mscorlib]System.Collections.Generic.List`1<valuetype Program/GroupByDateType> Program::_GroupByItems
    	IL_002b: ldloc.0
    
    	IL_002c: ret
    } // end of method Program::get_GroupByItems

    .method public hidebysig specialname 
    	instance class [mscorlib]System.Collections.Generic.List`1<valuetype Program/GroupByDateType> get_GroupByItems2 () cil managed 
    {
    	// Method begins at RVA 0x2052
    	// Code size 26 (0x1a)
    	.maxstack 8
    
    	IL_0000: ldtoken Program/GroupByDateType
    	IL_0005: call class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
    	IL_000a: call class [mscorlib]System.Array [mscorlib]System.Enum::GetValues(class [mscorlib]System.Type)
    	IL_000f: call class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0> [System.Core]System.Linq.Enumerable::Cast<valuetype Program/GroupByDateType>(class [mscorlib]System.Collections.IEnumerable)
    	IL_0014: call class [mscorlib]System.Collections.Generic.List`1<!!0> [System.Core]System.Linq.Enumerable::ToList<valuetype Program/GroupByDateType>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>)
    	IL_0019: ret
    } // end of method Program::get_GroupByItems2

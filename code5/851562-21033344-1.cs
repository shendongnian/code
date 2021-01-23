        .method private hidebysig 
        	instance class [mscorlib]System.Threading.Tasks.Task TestAsync2 () cil managed 
        {
        	// Method begins at RVA 0x21d8
        	// Code size 23 (0x17)
        	.maxstack 2
        	.locals init (
        		[0] class [mscorlib]System.Threading.Tasks.Task CS$1$0000
        	)
    
        	IL_0000: nop
        	IL_0001: ldarg.0
        	IL_0002: ldftn instance class [mscorlib]System.Threading.Tasks.Task SOTestProject.Program::'<TestAsync2>b__4'()
        	IL_0008: newobj instance void class [mscorlib]System.Func`1<class [mscorlib]System.Threading.Tasks.Task>::.ctor(object, native int)
        	IL_000d: call class [mscorlib]System.Threading.Tasks.Task [mscorlib]System.Threading.Tasks.Task::Run(class [mscorlib]System.Func`1<class [mscorlib]System.Threading.Tasks.Task>)
        	IL_0012: stloc.0
        	IL_0013: br.s IL_0015
    
        	IL_0015: ldloc.0
        	IL_0016: ret
        } // end of method Program::TestAsync2

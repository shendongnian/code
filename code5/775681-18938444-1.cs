    public struct MutableStruct
    {
        public int Foo { get; set; }
        public override string ToString()
        {
            return Foo.ToString();
        }
    }
    
    void Main()
    {
        // Grab the backing field (I'm being really lazy here)
    	var field = typeof(MutableStruct).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)[0];
    
        // Module used by DynamicMethod by default doesn't play nice with pointers
        //   so make a new one
    	var asm = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName("Example"), AssemblyBuilderAccess.Run);
        var module = asm.DefineDynamicModule("DynamicModule");
    
        // skipVisibility, using a backing field!
    	var dynMtd = new DynamicMethod("Evil", typeof(void), new [] { typeof(object), typeof(int) }, module, skipVisibility: true);
    	var il = dynMtd.GetILGenerator();
    	il.Emit(OpCodes.Ldarg_0);                       // object
    	il.Emit(OpCodes.Unbox, typeof(MutableStruct));  // MutableStruct&
    	il.Emit(OpCodes.Conv_U);                        // MutableStruct*
    	il.Emit(OpCodes.Ldflda, field);                 // int*
    	il.Emit(OpCodes.Ldarg_1);                       // int* int
    	il.Emit(OpCodes.Stind_I4);                      // --empty--
    	il.Emit(OpCodes.Ret);                           // --empty--
    	
    	var del = (Action<object, int>)dynMtd.CreateDelegate(typeof(Action<object, int>));
    	
    	var mut = new MutableStruct { Foo = 123 };
    	
    	var boxed= (object)mut;
    	
    	del(boxed, 456);
        var unboxed = (MutableStruct)boxed;
        // unboxed.Foo = 456, mut.Foo = 123
    }

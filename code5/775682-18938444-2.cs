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
        var foo = typeof(MutableStruct).GetProperty("Foo");
    	var setFoo = foo.SetMethod;
    
        var dynMtd = new DynamicMethod("Evil", typeof(void), new [] { typeof(object), typeof(int) });
        var il = dynMtd.GetILGenerator();
        il.Emit(OpCodes.Ldarg_0);                       // object
        il.Emit(OpCodes.Unbox, typeof(MutableStruct));  // MutableStruct&
        il.Emit(OpCodes.Ldarg_1);                       // MutableStruct& int
    	il.Emit(OpCodes.Call, setFoo);                  // --empty--
        il.Emit(OpCodes.Ret);                           // --empty--
    
        var del = (Action<object, int>)dynMtd.CreateDelegate(typeof(Action<object, int>));
    
        var mut = new MutableStruct { Foo = 123 };
    
        var boxed= (object)mut;
    
        del(boxed, 456);
    
        var unboxed = (MutableStruct)boxed;
        // unboxed.Foo = 456, mut.Foo = 123
    }

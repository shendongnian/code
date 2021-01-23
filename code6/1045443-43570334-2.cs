    public static class IL<T>
    {
        public delegate bool delRefEq(ref T a, ref T b);
    
        public static readonly delRefEq RefEquals;
    
        static IL()
        {
            var dm = new DynamicMethod(
                "__IL_RefEquals<" + typeof(T).FullName + ">",
                typeof(bool),
                new[] { typeof(T).MakeByRefType(), typeof(T).MakeByRefType() },
                typeof(Object),
                true)
            { InitLocals = false };
    
            var il = dm.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Ceq);
            il.Emit(OpCodes.Ret);
    
            RefEquals = (delRefEq)dm.CreateDelegate(typeof(delRefEq));
        }
    };

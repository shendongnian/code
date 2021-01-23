            var theirObj = new TheirClass();
            var t = theirObj.GetType();
            var fooBar = t.GetMethod("FooBar"); // Byte& FooBar()
            DynamicMethod dm = new DynamicMethod(
                "MyFooBar",
                MethodAttributes.Public | MethodAttributes.Static,
                CallingConventions.Standard,
                typeof(IntPtr), 
                new Type[] { typeof(TheirClass) },
                typeof(TheirClass),
                true);
            var ilg = dm.GetILGenerator();
            ilg.Emit(OpCodes.Ldarg_0);
            ilg.Emit(OpCodes.Call, foobar);
            ilg.Emit(OpCodes.Ret);
            var del = dm.CreateDelegate(typeof(Func<TheirClass,IntPtr>));
            var ret = (IntPtr)del.DynamicInvoke(theirObject);
            byte[] buf = new byte[theirObj.FooBarSize()]; //no need for reflection/IL here
            // not sure about the following, it works, but should it be inside an "unsafe" section?
            Marshal.Copy(ret, buf, 0, buf.Length);

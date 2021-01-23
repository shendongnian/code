    public delegate void SetHandler<T>(ref T source, object value) where T : struct;
    
            private static SetHandler<T> GetDelegate<T>(FieldInfo fieldInfo) where T : struct
            {
                var type = typeof(T);
                DynamicMethod dm = new DynamicMethod("setter", typeof(void), new Type[] { type.MakeByRefType(), typeof(object) }, type, true);
                ILGenerator setGenerator = dm.GetILGenerator();
    
                setGenerator.Emit(OpCodes.Ldarg_0);
                setGenerator.DeclareLocal(type);
                setGenerator.Emit(OpCodes.Ldarg_0);
                setGenerator.Emit(OpCodes.Ldnull);
                setGenerator.Emit(OpCodes.Stind_Ref);
                setGenerator.Emit(OpCodes.Ldarg_1);
                setGenerator.Emit(OpCodes.Unbox_Any, fieldInfo.FieldType);
                setGenerator.Emit(OpCodes.Stfld, fieldInfo);
                setGenerator.Emit(OpCodes.Ldloc, 0);
                setGenerator.Emit(OpCodes.Box, type);
                setGenerator.Emit(OpCodes.Ret);
                    return (SetHandler<T>)dm.CreateDelegate(typeof(SetHandler<>).MakeGenericType(type));
            }
    
            static void Main(string[] args)
            {
                MyStruct myStruct = new MyStruct();
                myStruct.myField = 3;
    
                FieldInfo fi = typeof(MyStruct).GetField("myField", BindingFlags.Public | BindingFlags.Instance);
    
                var setter = GetDelegate<MyStruct>(fi);
                setter(ref myStruct, 111);
                Console.WriteLine(myStruct.myField);
            }

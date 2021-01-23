     public delegate void DynamicMethodDelegate(object _target, params object[] _params); 
      
        public class DynamicDelegateStaticFactory
        {
            public static DynamicMethodDelegate CreateMethodCaller(MethodInfo method)
            {               
                ParameterInfo[] parameters = method.GetParameters();
                Type[] args = { typeof(object), typeof(object[]) };
                DynamicMethod dynam =
                    new DynamicMethod
                        (
                              method.Name
                            , method.ReturnType
                            , args
                            , typeof(DynamicDelegateStaticFactory)
                            , true
                        );
                //Add parmeter attributes to the new method from the existing method
                for (int i = 0; i < parameters.Length; i++)
                {
                    dynam.DefineParameter
                    (
                        i,
                        parameters[i].Attributes,
                        parameters[i].Name
                    );
                }
                ILGenerator il = dynam.GetILGenerator();
                // If method isn't static push target instance on top of stack.
                if (!method.IsStatic)
                {
                    // Argument 0 of dynamic method is target instance.
                    il.Emit(OpCodes.Ldarg_0);
                }
               
                // Lay out args array onto stack.        
                LocalBuilder[] locals = new LocalBuilder[parameters.Length];
                List<LocalBuilder> outOrRefLocals = new List<LocalBuilder>();
                for (int i = 0; i < parameters.Length; i++ )
                {
                    //Push args array reference onto the stack, followed
                    //by the current argument index (i). The Ldelem_Ref opcode
                    //will resolve them to args[i].
                    if (!parameters[i].IsOut)
                    {
                        // Argument 1 of dynamic method is argument array.
                        il.Emit(OpCodes.Ldarg_1);
                        il.Emit(OpCodes.Ldc_I4, i);
                        il.Emit(OpCodes.Ldelem_Ref);
                    }
                    // If parameter [i] is a value type perform an unboxing.
                    Type parameterType = parameters[i].ParameterType;
                    if (parameterType.IsValueType)
                    {
                        il.Emit(OpCodes.Unbox_Any, parameterType);
                    }
                }
                //Create locals for out parameters
                for (int i = 0; i < parameters.Length; i++)
                {
                    if (parameters[i].IsOut)
                    {
                        locals[i] = il.DeclareLocal(parameters[i].ParameterType.GetElementType());
                        il.Emit(OpCodes.Ldloca, locals[locals.Length - 1]);
                    }
                }
                if (method.IsFinal || !method.IsVirtual)
                {
                    il.Emit(OpCodes.Call, method);
                }
                else
                {
                    il.Emit(OpCodes.Callvirt, method);
                }
                for (int idx = 0; idx < parameters.Length; ++idx)
                {
                    if (parameters[idx].IsOut || parameters[idx].ParameterType.IsByRef)
                    {
                        il.Emit(OpCodes.Ldarg_1);
                        il.Emit(OpCodes.Ldc_I4, idx);
                        il.Emit(OpCodes.Ldloc, locals[idx].LocalIndex);
                        if (parameters[idx].ParameterType.GetElementType().IsValueType)
                            il.Emit(OpCodes.Box, parameters[idx].ParameterType.GetElementType());
                        il.Emit(OpCodes.Stelem_Ref);
                    }
                }
                if (method.ReturnType != typeof(void))
                {
                    // If result is of value type it needs to be boxed
                    if (method.ReturnType.IsValueType)
                    {
                        il.Emit(OpCodes.Box, method.ReturnType);
                    }
                }
                else
                {
                    il.Emit(OpCodes.Ldnull);
                }
                il.Emit(OpCodes.Ret);
                return (DynamicMethodDelegate)dynam.CreateDelegate(typeof(DynamicMethodDelegate));
            }
            private static void EmitUnboxOrCast(ILGenerator il, Type typeOnStack)
            {
                if (typeOnStack.IsValueType || typeOnStack.IsGenericParameter)
                {
                    il.Emit(OpCodes.Unbox_Any, typeOnStack);
                }
                else
                {
                    il.Emit(OpCodes.Castclass, typeOnStack);
                }
            }

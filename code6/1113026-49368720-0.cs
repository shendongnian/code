    public static PropValDelegate CreatePropertyGetter<TIn>(PropertyInfo propertyInfo, TIn ownerObj)
		{
			MethodInfo propertyGetter = propertyInfo.GetGetMethod();
			DynamicMethod dynGetter = new DynamicMethod
			(
				String.Empty, typeof(object), new Type[1] {typeof(TIn)},
				propertyInfo.DeclaringType, true
			);
			ILGenerator ilGen = dynGetter.GetILGenerator();
			ilGen.Emit(propertyInfo.DeclaringType.IsValueType ? OpCodes.Ldarga : OpCodes.Ldarg, 0);
			ilGen.EmitCall(propertyInfo.DeclaringType.IsValueType ? OpCodes.Call : OpCodes.Callvirt, propertyGetter, null);
			if (propertyInfo.PropertyType.IsValueType)
			{
				ilGen.Emit(OpCodes.Box, propertyInfo.PropertyType);
			}
			ilGen.Emit(OpCodes.Ret);
			return (lambdaObject) => (PropValDelegate<TIn>)dynGetter.CreateDelegate(typeof(PropValDelegate<TIn>));
		}

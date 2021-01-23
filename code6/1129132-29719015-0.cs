		static public Type[] ListeTypeArgumentZuBaseOderInterface(
			this Type Type,
			Type BaseGenericTypeDefinition)
		{
			if (null == Type || null == BaseGenericTypeDefinition)
			{
				return null;
			}
			if (BaseGenericTypeDefinition.IsInterface)
			{
				var MengeInterface = Type.GetInterfaces();
				if (null != MengeInterface)
				{
					foreach (var Interface in MengeInterface)
					{
						if (!Interface.IsGenericType)
						{
							continue;
						}
						var InterfaceGenericTypeDefinition = Interface.GetGenericTypeDefinition();
						if (!InterfaceGenericTypeDefinition.Equals(BaseGenericTypeDefinition))
						{
							continue;
						}
						return Interface.GenericTypeArguments;
					}
				}
			}
			else
			{
				var BaseTypeAktuel = Type;
				while (null != BaseTypeAktuel)
				{
					if (BaseTypeAktuel.IsGenericType)
					{
						var BaseTypeGenericTypeDefinition = BaseTypeAktuel.GetGenericTypeDefinition();
						if (BaseTypeGenericTypeDefinition.Equals(BaseGenericTypeDefinition))
						{
							return BaseTypeAktuel.GenericTypeArguments;
						}
					}
					BaseTypeAktuel = BaseTypeAktuel.BaseType;
				}
			}
			return null;
		}
		static public Type IEnumerableTypeArgumentExtrakt(
			this Type TypeImplementingEnumerable)
		{
			var GenericTypeArguments =
				ListeTypeArgumentZuBaseOderInterface(TypeImplementingEnumerable, typeof(IEnumerable<>));
			if (null == GenericTypeArguments)
			{
				//	does not implement IEnumerable<>
				return null;
			}
			return GenericTypeArguments.FirstOrDefault();
        }
		public static String Join<T>(this IEnumerable<T> enumerable)
		{
			//	¡the typeof() has to refer to the class containing this Method!:
			var SelfType = typeof(Extension);
            var IEnumerableTypeArgument = IEnumerableTypeArgumentExtrakt(typeof(T));
            if (null != IEnumerableTypeArgument)
            {
				System.Reflection.MethodInfo method = SelfType.GetMethod("Join");
				System.Reflection.MethodInfo generic = method.MakeGenericMethod(IEnumerableTypeArgument);
				return String.Join(",", enumerable.Select(e => generic.Invoke(null, new object[] { e })));
			}
			return String.Join(",", enumerable.Select(e => e.ToString()));
		}

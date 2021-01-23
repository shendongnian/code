	static class EntityConverter
	{
		private static Dictionary<Type, Type> _mappings =
			new Dictionary<Type, Type>()
			{
				{ typeof(GDeerParkEntity.Busremove), typeof(ServiceProxy.Busremove) },
				{ typeof(GDeerParkEntity.Buseartag), typeof(ServiceProxy.Buseartag) },
				{ typeof(ServiceProxy.Busremove), typeof(GDeerParkEntity.Busremove) },
				{ typeof(ServiceProxy.Buseartag), typeof(GDeerParkEntity.Buseartag) },
			};
		private static object ConvertEntity(object source, Type targetType)
		{
			var target = Activator.CreateInstance(targetType);
			TransferValues(source, target);
			return target;
		}
		private static void TransferValues(object source, object target)
		{
			var sourceProperties = source.GetType().GetProperties();
			var targetProperties = target.GetType().GetProperties();
			foreach(var srcProperty in sourceProperties)
			{
				var targetProperty = targetProperties.FirstOrDefault(p => p.Name == srcProperty.Name);
				if(targetProperty == null)
				{
					continue;
				}
				object value = srcProperty.GetValue(source);
				if(_mappings.ContainsKey(srcProperty.PropertyType))
				{
					value = ConvertEntity(value, _mappings[srcProperty.PropertyType]);
				}
				targetProperty.SetValue(target, value);
			}
		}
		public static TDestination ConvertEntity<TSource, TDestination>(TSource source)
		{
			var destination = Activator.CreateInstance<TDestination>();
			TransferValues(source, destination);
			return destination;
		}
	}

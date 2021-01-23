	/// <summary>
	/// Maps instances of <typeparam name="TSource"/> to new instances of
	/// <typeparam name="TDestination"/> by copying across accessible public
	/// instance properties whose names match.
	/// </summary>
	/// <remarks>
	/// Internally uses a compiled Expression, so mapping should be quick at
	/// the expense of <see cref="Mapper"/> initialisation.
	/// </remarks>
	public class Mapper<TSource, TDestination>
		where TDestination : new()
	{
		readonly Func<TSource, TDestination> map;
		public Mapper()
		{
			this.map = GenerateMapping();
		}
		static Func<TSource, TDestination> GenerateMapping()
		{
			var sourceProperties = GetPublicInstancePropertiesWithAccessors<TSource>(property => property.GetGetMethod());
			var destinationProperties = GetPublicInstancePropertiesWithAccessors<TDestination>(property => property.GetSetMethod());
			var source = Expression.Parameter(typeof(TSource));
			var destination = Expression.Variable(typeof(TDestination));
			var copyPropertyValues = from sourceProperty in sourceProperties
									 from destinationProperty in destinationProperties
									 where sourceProperty.Name.Equals(destinationProperty.Name, StringComparison.Ordinal)
									 select Expression.Assign(
										 Expression.Property(destination, destinationProperty),
										 Expression.Property(source, sourceProperty)
									 );
			var variables = new[] { destination };
			var assignNewDestinationInstance = Expression.Assign(destination, Expression.New(typeof(TDestination)));
			var returnDestinationInstance = new Expression[] { destination };
			var statements =
				new[] { assignNewDestinationInstance }
				.Concat(copyPropertyValues)
				.Concat(returnDestinationInstance);
			var body = Expression.Block(variables, statements);
			var parameters = new[] { source };
			var method = Expression.Lambda<Func<TSource, TDestination>>(body, parameters);
			return method.Compile();
		}
		/// <summary>
		/// Gets public instance properties of <typeparamref name="T"/> that
		/// have accessible accessors defined by <paramref name="getAccessor"/>.
		/// </summary>
		static IEnumerable<PropertyInfo> GetPublicInstancePropertiesWithAccessors<T>(Func<PropertyInfo, MethodInfo> getAccessor)
		{
			var type = typeof(T);
			var publicInstanceProperties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
			return from property in publicInstanceProperties
				   let accessor = getAccessor(property)
				   where accessor != null
				   select property;
		}
		public TDestination Map(TSource source)
		{
			return map(source);
		}
	}

	Type[] parameterTypes = new Type[] { typeof(int), typeof(object) };
	Type tupleType = typeof(CustomTuple<,>).MakeGenericType(parameterTypes);
	ParameterExpression x = Expression.Parameter(typeof(Entity));
	NewExpression body = Expression.New(tupleType.GetConstructor(new Type[0]), new Expression[0]);
	MemberBinding binding1 = Expression.Bind(
		typeof(CustomTuple<,>).MakeGenericType(parameterTypes).GetProperty("Item1"),
		Expression.Property(x, "Value"));
	MemberInitExpression memberInitExpression =
		Expression.MemberInit(
			body,
			binding1);
	Expression<Func<Entity, object>> exp = Expression.Lambda<Func<Entity, object>>(memberInitExpression, x);
	using (MyDbContext context = new MyDbContext())
	{
		var list = context.Entities.Select(exp).ToList();
	}

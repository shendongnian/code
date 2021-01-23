	public class Accessor<TProp> : IAccessor<TProp>
	{
		private readonly Func<TProp> _getter;
		private readonly Action<TProp> _setter;
		internal Accessor(Expression<Func<TProp>> e)
		{
			if (!(e.Body is System.Linq.Expressions.MemberExpression))
				throw new ArgumentException("Invalid expression type supplied.", "e");
			MemberExpression memacc = (MemberExpression)e.Body;
			if (memacc.Type != typeof(TProp))
				throw new ArgumentException("Invalid expression return type.", "e");
			var parmValue = Expression.Parameter(typeof(TProp), "value");
			var assign = Expression.Assign(memacc, parmValue);
			_getter = e.Compile();
			_setter = Expression.Lambda<Action<TProp>>(assign, new[] { parmValue }).Compile();
		}
		public TProperty Value
		{
			get { return _getter(_instance); }
			set { _setter(_instance, value); }
		}
	}
	// usage:
	var obj = new TextBox();
	var acc = Factory.Accessor(() => obj.Enabled);

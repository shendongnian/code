	public interface IDisplayColumn
	{
		string Title { get; set; }
		bool Visible { get; set; }
		int Order { get; set; }
		Func<object, object> Value { get; }
		T GetValue<T>(object source);
	}
	public class DisplayColumn<T>: IDisplayColumn
	{
		public string Title { get; set; }
		public bool Visible { get; set; }
		public int Order { get; set; }
		public Func<object, object> Value { get; set; }
		public override string ToString()
		{
			return Title;
		}
		public TValue GetValue<TValue>(object source)
		{
			return (TValue)Convert.ChangeType(Value(source), typeof(TValue));
		}
		public Func<T, object> Selector
		{
			set
			{
				Value = value.ConvertObject<T>();
			}
		}
	}
	
	public interface IColumnSet
	{
		Type TypeHandled { get; }
		IEnumerable<IDisplayColumn> Columns { get; }
	}
	public class ColumnSet<T>: IColumnSet
	{
		public Type TypeHandled
		{
			get
			{
				return typeof(T);
			}
		}
		public IEnumerable<IDisplayColumn> Columns { get; set; }
	}
	
	public static Func<object, object> ConvertObject<T>(this Func<T, object> func)
	{
		Contract.Requires(func != null);
		var param = Expression.Parameter(typeof(object));
		var convertedParam = new Expression[] { Expression.Convert(param, typeof(T)) };
		Expression call;
		call = Expression.Convert(
			func.Target == null
				? Expression.Call(func.Method, convertedParam)
				: Expression.Call(Expression.Constant(func.Target), func.Method, convertedParam)
			, typeof(object));
		var delegateType = typeof(Func<,>).MakeGenericType(typeof(object), typeof(object));
		return (Func<object, object>)Expression.Lambda(delegateType, call, param).Compile();
	}
	

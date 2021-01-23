	public interface IAccessor<TProperty>
	{
		bool Value { get; set; }
	}
	public class genAccessor<TClass, TProperty> : IAccessor<TProperty>
	{
		private readonly TClass _instance;
		private readonly Func<TClass, TProperty> _getter;
		private readonly Action<TClass, TProperty> _setter;
		internal genAccessor(TClass instance, Func<TClass, TProperty> getter, Action<TClass, TProperty> setter)
		{
			_instance = instance;
			_getter = getter;
			_setter = setter;
		}
		public TProperty Value
		{
			get { return _getter(_instance); }
			set { _setter(_instance, value); }
		}
	}

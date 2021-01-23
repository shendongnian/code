    var source = new Source() { A = 3 };
    var dest = new Dest();
    dest.InjectFrom<MyInjector>(source);
	public class Source
	{
		public int A { get; set; }
		public bool SetA { get; set; }
	}
	public class Dest
	{
		public int A { get; set; }
	}
	public class MyInjector : LoopValueInjection // or some other base class!
	{
		protected override void Inject(object source, object target)
		{
			if (source is BaseEntityViewModel) _baseEntityViewModel = (BaseEntityViewModel)source;
			base.Inject(source, target);
		}
		protected override bool UseSourceProp(string sourcePropName)
		{
			if (_baseEntityViewModel is BaseEntityViewModel)
				return _baseEntityViewModel.SetProperties.Contains(sourcePropName);
			else
				return base.UseSourceProp(sourcePropName);
		}
	}

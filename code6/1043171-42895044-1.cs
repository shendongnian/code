	[MarkupExtensionReturnType(typeof(BindingExpression))]
	public sealed class MyBindingExtension : MarkupExtension
	{
		public MyBindingExtension() { }
		public MyBindingExtension(Binding b) { this.Binding = b; }
		Binding Binding { get; set; }
		public override Object ProvideValue(IServiceProvider sp)
		{
			Binding b;
			IProvideValueTarget pvt;
			if ((pvt = sp as IProvideValueTarget) == null || (b = this.Binding) == null)
				return this;    // (...avoids Visual Studio XAML Designer convulsions)
			var dobj = (DependencyObject)pvt.TargetObject;
			var dp = (DependencyProperty)pvt.TargetProperty;
			var cur_val = dobj.GetValue(dp);
			b.Converter = /* ... */;
			b.ConverterParameter = /* ... */;
			b.StringFormat = /* ... */;
			return b.ProvideValue(sp);
		}
	};

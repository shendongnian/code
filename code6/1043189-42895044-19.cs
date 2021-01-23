	[MarkupExtensionReturnType(typeof(BindingExpression))]
	[ContentProperty(nameof(SourceBinding))]
	public sealed class MyBindingExtension : MarkupExtension
	{
		public MyBindingExtension() { }
		public MyBindingExtension(Binding b) => this.b = b;
		Binding b;
		public Binding SourceBinding
		{
			get => b;
			set => b = value;
		}
		public override Object ProvideValue(IServiceProvider sp)
		{
			if (b == null)
				throw new ArgumentNullException(nameof(SourceBinding));
			if (!(sp is IProvideValueTarget pvt))
				return null;                // prevents XAML Designer crashes
			if (!(pvt.TargetObject is DependencyObject))
				return pvt.TargetObject;    // required for template re-binding
			var dp = (DependencyProperty)pvt.TargetProperty;
			/*** INSERT YOUR CODE HERE ***/
			// finalize binding as a BindingExpression attached to target
			return b.ProvideValue(sp);
		}
	};

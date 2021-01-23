	[MarkupExtensionReturnType(typeof(BindingExpression))]
    [ContentProperty("SourceBinding")]
	public sealed class MyBindingExtension : MarkupExtension
	{
		public MyBindingExtension() { }
		public MyBindingExtension(Binding b) { this.b = b; }
		Binding b;
		public Binding SourceBinding { get { return b; } set { b = value; } }
		public override Object ProvideValue(IServiceProvider sp)
		{
			if (b == null)
				throw new ArgumentNullException(nameof(SourceBinding));
			IProvideValueTarget pvt;
			if ((pvt = sp as IProvideValueTarget) == null)
				return null;         // prevents XAML Designer crashes
			DependencyObject dobj;
			if ((dobj = pvt.TargetObject as DependencyObject) == null)
				return pvt.TargetObject;    // required for template re-binding
			var dp = (DependencyProperty)pvt.TargetProperty;
			/*** INSERT YOUR CODE HERE ***/
			// finalize binding as a BindingExpression attached to target
			return b.ProvideValue(sp);
		}
	}

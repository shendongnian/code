	[MarkupExtensionReturnType(typeof(BindingExpression))]
	public sealed class MyBindingExtension : MarkupExtension
	{
		public MyBindingExtension(Binding b) { this.m_b = b; }
		Binding m_b;
		public override Object ProvideValue(IServiceProvider sp)
		{
			m_b.StringFormat = "---{0}---";   // modify wrapped Binding first...
			return m_b.ProvideValue(sp);    // ...then obtain its BindingExpression
		}
	}

public static class Example
{
	public static BindingExpressionBase GetMyBinding(DependencyObject obj)
	{
		return (BindingExpressionBase)obj.GetValue(MyBindingProperty);
	}
	public static void SetMyBinding(DependencyObject obj, BindingExpressionBase value)
	{
		obj.SetValue(MyBindingProperty, value);
	}
	public static readonly DependencyProperty MyBindingProperty =
		DependencyProperty.RegisterAttached(
			name: 				"MyBinding",
			propertyType: 		typeof(BindingExpressionBase),
			ownerType: 			typeof(Example),
			defaultMetadata: 	new FrameworkPropertyMetadata(null));
}
DependencyObject obj = ...;
BindingBase bb = Example.GetMyBinding(obj)?.ParentBindingBase;
				

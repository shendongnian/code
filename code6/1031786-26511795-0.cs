	public static class DependencyPropertyExtensions
	{
		public static bool UpdateSource(this FrameworkElement source, DependencyProperty property)
		{
			var binding = source.GetBindingExpression(property);
			if (binding != null)
			{
				binding.UpdateSource();
				return true;
			}
			return false;
		}
	}

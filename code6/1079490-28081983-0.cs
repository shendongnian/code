    public class BindingProxy : Freezable
	{
		#region Overrides of Freezable
		protected override Freezable CreateInstanceCore()
		{
			try
            {
                return new BindingProxy();
            }
            catch
            {
                return null;
            }
		}
		#endregion
		public object Data
		{
			get { return (object)GetValue(DataProperty); }
			set { SetValue(DataProperty, value); }
		}
		public static readonly DependencyProperty DataProperty =
			DependencyProperty.Register("Data", typeof(object),
										 typeof(BindingProxy));
	}

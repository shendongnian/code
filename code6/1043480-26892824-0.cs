	/*
	 * Use in conjuction with other Controls that do not have the appropriate
	 * visualStates to indicate ValidationErrors.
	 * Either set DataContextValidationTargetPath to have this
	 * ValidationErrorBorder show validation errors that occur at the targeted
	 * property of the DataContext
	 * or bind ValidationTarget to any target you wish to have this
	 * ValidationErrorBorder show validation errors occuring for the bound target.
	 */
	[TemplateVisualState(GroupName="ValidationStates", Name = "Valid")]
	[TemplateVisualState(GroupName="ValidationStates", Name = "InvalidUnfocused")]
	[TemplateVisualState(GroupName="ValidationStates", Name = "InvalidFocused")]
	public class ValidationErrorBorder : ContentControl
	{
		public object ValidationTarget
		{
			get { return GetValue( ValidationTargetProperty ); }
			set { SetValue( ValidationTargetProperty, value ); }
		}
		public static readonly DependencyProperty ValidationTargetProperty =
			DependencyProperty.Register( "ValidationTarget", typeof( object ),
			typeof( ValidationErrorBorder ), new PropertyMetadata( null ) );
		public string DataContextValidationTargetPath
		{
			get
			{
			  return (string) GetValue( DataContextValidationTargetPathProperty );
			}
			set { SetValue( DataContextValidationTargetPathProperty, value ); }
		}
		public static readonly DependencyProperty
			DataContextValidationTargetPathProperty =
			DependencyProperty.Register( "DataContextValidationTargetPath",
			typeof( string ), typeof( ValidationErrorBorder ),
			new PropertyMetadata( null, HandlePathChanged ) );
		private static void HandlePathChanged(DependencyObject d,
			DependencyPropertyChangedEventArgs e)
		{
			((ValidationErrorBorder) d).HandlePathChanged();
		}
		private void HandlePathChanged()
		{
			if (DataContextValidationTargetPath != null)
				SetBinding(ValidationTargetProperty,
					new Binding(DataContextValidationTargetPath));
			else
				ClearValue( ValidationTargetProperty );
		}
		public ValidationErrorBorder()
		{
			DefaultStyleKey = typeof( ValidationErrorBorder );
		}
	}

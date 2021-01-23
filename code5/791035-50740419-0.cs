	public class DataGridNumberColumn : DataGridTextColumn
	{
		private TextBoxInputBehavior _behavior;
		protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
		{
			var element = base.GenerateElement(cell, dataItem);
			// A clever workaround the StringFormat issue with the Binding set to the 'Binding' property. If you use StringFormat it
			// will only work in edit mode if you changed the value, otherwise it will retain formatting when you enter editing.
			if (!string.IsNullOrEmpty(StringFormat))
			{
				BindingOperations.ClearBinding(element, TextBlock.TextProperty);
				BindingOperations.SetBinding(element, FrameworkElement.TagProperty, Binding);
				BindingOperations.SetBinding(element,
					TextBlock.TextProperty,
					new Binding
					{
						Source = element,
						Path = new PropertyPath("Tag"),
						StringFormat = StringFormat
					});
			}
			return element;
		}
		protected override object PrepareCellForEdit(FrameworkElement editingElement, RoutedEventArgs editingEventArgs)
		{
			if (!(editingElement is TextBox textBox))
				return null;
			var originalText = textBox.Text;
			_behavior = new TextBoxInputBehavior
			{
				IsNumeric = true,
				EmptyValue = EmptyValue,
				IsInteger = IsInteger
			};
			_behavior.Attach(textBox);
			textBox.Focus();
			if (editingEventArgs is TextCompositionEventArgs compositionArgs) // User has activated editing by already typing something
			{
				if (compositionArgs.Text == "\b") // Backspace, it should 'clear' the cell
				{
					textBox.Text = EmptyValue;
					textBox.SelectAll();
					return originalText;
				}
				if (_behavior.ValidateText(compositionArgs.Text))
				{
					textBox.Text = compositionArgs.Text;
					textBox.Select(textBox.Text.Length, 0);
					return originalText;
				}
			}
			if (!(editingEventArgs is MouseButtonEventArgs) || !PlaceCaretOnTextBox(textBox, Mouse.GetPosition(textBox)))
				textBox.SelectAll();
			return originalText;
		}
		private static bool PlaceCaretOnTextBox(TextBox textBox, Point position)
		{
			int characterIndexFromPoint = textBox.GetCharacterIndexFromPoint(position, false);
			if (characterIndexFromPoint < 0)
				return false;
			textBox.Select(characterIndexFromPoint, 0);
			return true;
		}
		protected override void CancelCellEdit(FrameworkElement editingElement, object uneditedValue)
		{
			UnwireTextBox();
			base.CancelCellEdit(editingElement, uneditedValue);
		}
		protected override bool CommitCellEdit(FrameworkElement editingElement)
		{
			UnwireTextBox();
			return base.CommitCellEdit(editingElement);
		}
		private void UnwireTextBox() => _behavior.Detach();
		public static readonly DependencyProperty EmptyValueProperty = DependencyProperty.Register(
			nameof(EmptyValue),
			typeof(string),
			typeof(DataGridNumberColumn));
		public string EmptyValue
		{
			get => (string)GetValue(EmptyValueProperty);
			set => SetValue(EmptyValueProperty, value);
		}
		public static readonly DependencyProperty IsIntegerProperty = DependencyProperty.Register(
			nameof(IsInteger),
			typeof(bool),
			typeof(DataGridNumberColumn));
		public bool IsInteger
		{
			get => (bool)GetValue(IsIntegerProperty);
			set => SetValue(IsIntegerProperty, value);
		}
		public static readonly DependencyProperty StringFormatProperty = DependencyProperty.Register(
			nameof(StringFormat),
			typeof(string),
			typeof(DataGridNumberColumn));
		public string StringFormat
		{
			get => (string) GetValue(StringFormatProperty);
			set => SetValue(StringFormatProperty, value);
		}
	}

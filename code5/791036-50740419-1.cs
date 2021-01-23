	public class TextBoxInputBehavior : Behavior<TextBox>
	{
		#region DependencyProperties
		public static readonly DependencyProperty RegularExpressionProperty = DependencyProperty.Register(
			nameof(RegularExpression), 
			typeof(string), 
			typeof(TextBoxInputBehavior), 
			new FrameworkPropertyMetadata(".*"));
		public string RegularExpression
		{
			get
			{
				if (IsInteger)
					return @"^[0-9\-]+$";
				if (IsNumeric)
					return @"^[0-9.\-]+$";
				return (string)GetValue(RegularExpressionProperty);
			}
			set { SetValue(RegularExpressionProperty, value); }
		}
		public static readonly DependencyProperty MaxLengthProperty = DependencyProperty.Register(
			nameof(MaxLength), 
			typeof(int), 
			typeof(TextBoxInputBehavior),
			new FrameworkPropertyMetadata(int.MinValue));
		public int MaxLength
		{
			get { return (int)GetValue(MaxLengthProperty); }
			set { SetValue(MaxLengthProperty, value); }
		}
		public static readonly DependencyProperty EmptyValueProperty = DependencyProperty.Register(
			nameof(EmptyValue), 
			typeof(string), 
			typeof(TextBoxInputBehavior));
		public string EmptyValue
		{
			get { return (string)GetValue(EmptyValueProperty); }
			set { SetValue(EmptyValueProperty, value); }
		}
		public static readonly DependencyProperty IsNumericProperty = DependencyProperty.Register(
			nameof(IsNumeric), 
			typeof(bool), 
			typeof(TextBoxInputBehavior));
		public bool IsNumeric
		{
			get { return (bool)GetValue(IsNumericProperty); }
			set { SetValue(IsNumericProperty, value); }
		}
		public static readonly DependencyProperty IsIntegerProperty = DependencyProperty.Register(
			nameof(IsInteger),
			typeof(bool),
			typeof(TextBoxInputBehavior));
		public bool IsInteger
		{
			get { return (bool)GetValue(IsIntegerProperty); }
			set
			{
				if (value)
					SetValue(IsNumericProperty, true);
				SetValue(IsIntegerProperty, value);
			}
		}
		public static readonly DependencyProperty AllowSpaceProperty = DependencyProperty.Register(
			nameof(AllowSpace),
			typeof (bool),
			typeof (TextBoxInputBehavior));
		public bool AllowSpace
		{
			get { return (bool) GetValue(AllowSpaceProperty); }
			set { SetValue(AllowSpaceProperty, value); }
		}
		#endregion
		protected override void OnAttached()
		{
			base.OnAttached();
			AssociatedObject.PreviewTextInput += PreviewTextInputHandler;
			AssociatedObject.PreviewKeyDown += PreviewKeyDownHandler;
			DataObject.AddPastingHandler(AssociatedObject, PastingHandler);
		}
		
		protected override void OnDetaching()
		{
			base.OnDetaching();
			if (AssociatedObject == null)
				return;
			AssociatedObject.PreviewTextInput -= PreviewTextInputHandler;
			AssociatedObject.PreviewKeyDown -= PreviewKeyDownHandler;
			DataObject.RemovePastingHandler(AssociatedObject, PastingHandler);
		}
	    private void PreviewTextInputHandler(object sender, TextCompositionEventArgs e)
		{
			string text;
			if (AssociatedObject.Text.Length < AssociatedObject.CaretIndex)
				text = AssociatedObject.Text;
			else
			    text = TreatSelectedText(out var remainingTextAfterRemoveSelection)
					? remainingTextAfterRemoveSelection.Insert(AssociatedObject.SelectionStart, e.Text)
					: AssociatedObject.Text.Insert(AssociatedObject.CaretIndex, e.Text);
			e.Handled = !ValidateText(text);
		}
		private void PreviewKeyDownHandler(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Space)
				e.Handled = !AllowSpace;
			if (string.IsNullOrEmpty(EmptyValue))
				return;
			string text = null;
			// Handle the Backspace key
			if (e.Key == Key.Back)
			{
				if (!TreatSelectedText(out text))
				{
					if (AssociatedObject.SelectionStart > 0)
						text = AssociatedObject.Text.Remove(AssociatedObject.SelectionStart - 1, 1);
				}
			}
			// Handle the Delete key
			else if (e.Key == Key.Delete)
			{
				// If text was selected, delete it
				if (!TreatSelectedText(out text) && AssociatedObject.Text.Length > AssociatedObject.SelectionStart)
				{
					// Otherwise delete next symbol
					text = AssociatedObject.Text.Remove(AssociatedObject.SelectionStart, 1);
				}
			}
			if (text == string.Empty)
			{
				AssociatedObject.Text = EmptyValue;
				if (e.Key == Key.Back)
					AssociatedObject.SelectionStart++;
				e.Handled = true;
			}
		}
		private void PastingHandler(object sender, DataObjectPastingEventArgs e)
		{
			if (e.DataObject.GetDataPresent(DataFormats.Text))
			{
				var text = Convert.ToString(e.DataObject.GetData(DataFormats.Text));
				if (!ValidateText(text))
					e.CancelCommand();
			}
			else
				e.CancelCommand();
		}
		public bool ValidateText(string text)
		{
			return new Regex(RegularExpression, RegexOptions.IgnoreCase).IsMatch(text) && (MaxLength == int.MinValue || text.Length <= MaxLength);
		}
		/// <summary>
		/// Handle text selection.
		/// </summary>
		/// <returns>true if the character was successfully removed; otherwise, false.</returns>
		private bool TreatSelectedText(out string text)
		{
			text = null;
			if (AssociatedObject.SelectionLength <= 0)
				return false;
			var length = AssociatedObject.Text.Length;
			if (AssociatedObject.SelectionStart >= length)
				return true;
			if (AssociatedObject.SelectionStart + AssociatedObject.SelectionLength >= length)
				AssociatedObject.SelectionLength = length - AssociatedObject.SelectionStart;
			text = AssociatedObject.Text.Remove(AssociatedObject.SelectionStart, AssociatedObject.SelectionLength);
			return true;
		}
	}

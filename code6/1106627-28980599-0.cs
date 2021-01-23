	public static class TextBoxBehavior
	{
		public static bool GetAllowOnlyDecimalInput(TextBox texbox)
		{
			return (bool)texbox.GetValue(AllowOnlyDecimalInputProperty);
		}
		public static void SetAllowOnlyDecimalInput(
		  TextBox texbox, bool value)
		{
			texbox.SetValue(AllowOnlyDecimalInputProperty, value);
		}
		public static readonly DependencyProperty AllowOnlyDecimalInputProperty =
			DependencyProperty.RegisterAttached(
			"AllowOnlyDecimalInput",
			typeof(bool),
			typeof(TextBox),
			new UIPropertyMetadata(false, OnAllowOnlyDecimalInputChanged));
		static void OnAllowOnlyDecimalInputChanged(
		  DependencyObject depObj, DependencyPropertyChangedEventArgs e)
		{
			TextBox item = depObj as TextBox;
			if (item == null)
				return;
			if (e.NewValue is bool == false)
				return;
			if ((bool)e.NewValue)
				item.DoubleParse_KeyDown += OnTextBoxDoubleParse_KeyDown;
			else
				item.DoubleParse_KeyDown -= OnTextBoxDoubleParse_KeyDown;
		}
		static void OnTextBoxDoubleParse_KeyDown(object sender, KeyEventArgs e)
		{
			if (!Object.ReferenceEquals(sender, e.OriginalSource))
				return;
			TextBox item = e.OriginalSource as TextBox;
			if (item != null) {
				if (e.Key == Key.Decimal)
				{
					var textBox = sender as TextBox;
					if (textBox != null)
						textBox.Text += Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator);
				}
				else
				{
					e.Handled = (e.Key >= Key.D0 && e.Key <= Key.D9) ||
								(e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) || 
								e.Key == Key.Back || e.Key == Key.Delete ||
								e.Key == Key.Left || e.Key == Key.Right || e.Key == Key.Unknown;
				}
			}
		}
		#endregion // AllowOnlyDecimalInput
	}

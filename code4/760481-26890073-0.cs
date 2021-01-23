        [Bindable(false)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override string Text
		{
			get
			{
				string formattedValue = ParseEditText(base.Text);
				return formattedValue;
			}
			set
			{
				base.Text = value;
			}
		}
		protected override void UpdateEditText()
		{
			string formatSpecifier = "N";
			switch (DisplayFormatSpecifier)
			{
				case DisplayFormatSpecifier.Euro:
					formatSpecifier = "C";
					break;
				case DisplayFormatSpecifier.Percent:
					formatSpecifier = "P";
					break;
				case DisplayFormatSpecifier.Number:
					formatSpecifier = "N";
					break;
				default:
					formatSpecifier = "N";
					break;
			}
			formatSpecifier += DecimalPlaces.ToString();
			this.Text = this.Value.ToString(formatSpecifier.ToString(), formatProvider);
		}
		/// <summary>
		/// Remove the last character if is not a digit
		/// </summary>
		private string ParseEditText(string text)
		{
			string textReplace = text;
			if (!string.IsNullOrWhiteSpace(text))
			{
				char c = text[text.Length - 1];
				if (!char.IsDigit(c))
				{
					textReplace = textReplace.Replace(c.ToString(), string.Empty);
				}
			}
			return textReplace;
		}

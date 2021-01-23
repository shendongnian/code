	using System;
	using System.ComponentModel;
	using System.Collections;
	using System.Diagnostics;
	using System.Drawing;
	using System.Security.Permissions;
	using System.Text.RegularExpressions;
	using System.Windows.Forms;
	namespace System.Windows.Forms
	{
		public class NumericTextBox : TextBox
		{
			private System.ComponentModel.Container components = null;
			private bool _AllowNegatives = true;
			private int _Precision = 0;
			private char _CurrencyChar = (char)0;
			private bool _AutoFormat = true;
			private decimal _MinValue = Decimal.MinValue;
			private decimal _MaxValue = Decimal.MaxValue;
			/// <summary>
			/// Indicates if the negative values are allowed.
			/// </summary>
			[DefaultValue(true), RefreshProperties(RefreshProperties.All), Description("Indicates if the negative values are allowed."), Category("Behavior")]
			public bool AllowNegatives
			{
				get
				{
					return this._AllowNegatives;
				}
				set
				{
					this._AllowNegatives = value;
					if (!value)
					{
						if (this._MinValue < 0) this._MinValue = 0;
						if (this._MaxValue < 1) this._MaxValue = 1;
					}
				}
			}
			/// <summary>
			/// Indicates the maximum number of digits allowed after a decimal point.
			/// </summary>
			[DefaultValue(0), Description("Indicates the maximum number of digits allowed after a decimal point."), Category("Behavior")]
			public int Precision
			{
				get
				{
					return this._Precision;
				}
				set
				{
					if (value < 0)
					{
						throw new ArgumentOutOfRangeException("Precision", value.ToString(), "The value of precision must be an integer greater than or equal to 0.");
					}
					else
					{
						this._Precision = value;
					}
				}
			}
			/// <summary>
			/// Gets or sets the character to use as a currency symbol when validating input.
			/// </summary>
			[DefaultValue((char)0), Description("Gets or sets the character to use as a currency symbol when validating input."), Category("Behavior")]
			public char CurrencyChar
			{
				get
				{
					return this._CurrencyChar;
				}
				set
				{
					this._CurrencyChar = value;
				}
			}
			/// <summary>
			/// Indicates if the text in the textbox is automatically formatted. Missing currency symbols and trailing spaces are added where applicable.
			/// </summary>
			[DefaultValue(true), Description("Indicates if the text in the textbox is automatically formatted. Missing currency symbols and trailing spaces are added where applicable."), Category("Behavior")]
			public bool AutoFormat
			{
				get
				{
					return this._AutoFormat;
				}
				set
				{
					this._AutoFormat = value;
				}
			}
			/// <summary>
			/// Gets or sets the numerical value of the textbox.
			/// </summary>
			[Description("Gets or sets the numerical value of the textbox."), Category("Data")]
			public decimal Value
			{
				get
				{
					if (this.Text.Length == 0)
					{
						return (decimal)0;
					}
					else
					{
						return decimal.Parse(this.Text.Replace(this.CurrencyChar.ToString(), ""));
					}
				}
				set
				{
					if (value < 0 && !this.AllowNegatives)
					{
						throw new ArgumentException("The specified decimal is invalid, negative values are not permitted.");
					}
					this.Text = this.FormatText(value.ToString());
				}
			}
			/// <summary>
			/// Gets or sets the maximum numerical value of the textbox.
			/// </summary>
			[RefreshProperties(RefreshProperties.All), Description("Gets or sets the maximum numerical value of the textbox."), Category("Behavior")]
			public decimal MaxValue
			{
				get
				{
						return this._MaxValue;
				}
				set
				{
					if (value <= this._MinValue)
					{
						throw new ArgumentException("The Maximum value must be greater than the minimum value.", "MaxValue");
					}
					else
					{
						this._MaxValue = Decimal.Round(value, this.Precision);
					}
				}
			}
			/// <summary>
			/// Gets or sets the minimum numerical value of the textbox.
			/// </summary>
			[RefreshProperties(RefreshProperties.All), Description("Gets or sets the minimum numerical value of the textbox."), Category("Behavior")]
			public decimal MinValue
			{
				get
				{
					return this._MinValue;
				}
				set
				{
					if (value < 0 && !this.AllowNegatives)
					{
						throw new ArgumentException("The Minimum value cannot be negative when AllowNegatives is set to false.", "MinValue");
					}
					else if (value >= this._MaxValue)
					{
						throw new ArgumentException("The Minimum value must be less than the Maximum value.", "MinValue");
					}
					else
					{
						this._MinValue = Decimal.Round(value, this.Precision);
					}
				}
			}
			/// <summary>
			/// Create a new instance of the NumericTextBox class with the specified container.
			/// </summary>
			/// <param name="container">The container of the control.</param>
			public NumericTextBox(System.ComponentModel.IContainer container)
			{
				///
				/// Required for Windows.Forms Class Composition Designer support
				///
				container.Add(this);
				InitializeComponent();
			}
			/// <summary>
			/// Create a new instance of the NumericTextBox class.
			/// </summary>
			public NumericTextBox()
			{
				///
				/// Required for Windows.Forms Class Composition Designer support
				///
				InitializeComponent();
			}
			#region Component Designer generated code
			/// <summary>
			/// Required method for Designer support - do not modify
			/// the contents of this method with the code editor.
			/// </summary>
			private void InitializeComponent()
			{
				// 
				// NumericTextBox
				// 
				this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericTextBox_KeyPress);
				this.Validating += new System.ComponentModel.CancelEventHandler(this.NumericTextBox_Validating);
			}
			#endregion
			/// <summary>
			/// Checks to see if the specified text is valid for the properties selected.
			/// </summary>
			/// <param name="text">The text to test.</param>
			/// <returns>A boolean value indicating if the specified text is valid.</returns>
			protected bool IsValid(string text)
			{
				Regex check = new Regex("^" + ((this.AllowNegatives && this.MinValue < 0) ? (@"\-?") : "") + ((this.CurrencyChar != (char)0) ? (@"(" + Regex.Escape(this.CurrencyChar.ToString()) + ")?") : "") + @"\d*" + ((this.Precision > 0) ? (@"(\.\d{0," + this.Precision.ToString() + "})?") : "") + "$");
				if (!check.IsMatch(text)) return false;
				if (text == "-" || text == this.CurrencyChar.ToString() || text == "-" + this.CurrencyChar.ToString()) return true;
				Decimal val = Decimal.Parse(text);
				if (val < this.MinValue) return false;
				if (val > this.MaxValue) return false;
				return true;
			}
			/// <summary>
			/// Formats the specified text into the configured number format.
			/// </summary>
			/// <param name="text">The text to format.</param>
			/// <returns>The correctly formatted text.</returns>
			protected string FormatText(string text)
			{
				string format = "{0:" + this.CurrencyChar.ToString() + "0" + ((this.Precision > 0) ? "." + new String(Convert.ToChar("0"), this.Precision) : "") + ";-" + this.CurrencyChar.ToString() + "0" + ((this.Precision > 0) ? "." + new String(Convert.ToChar("0"), this.Precision) : "") + "; £0" + ((this.Precision > 0) ? "." + new String(Convert.ToChar("0"), this.Precision) : "") + "}";
				return String.Format(format, text).Trim();
			}
			/// <summary>
			/// Overrides message handler in order to pre-process and validate pasted data.
			/// </summary>
			/// <param name="m">Message</param>
			protected override void WndProc(ref Message m) 
			{
				switch (m.Msg)
				{
					case 0x0302:
						if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
						{
							string paste = Clipboard.GetDataObject().GetData(DataFormats.Text).ToString();
							string text = this.Text.Substring(0, this.SelectionStart) + paste + this.Text.Substring(this.SelectionStart + this.SelectionLength);
							if (this.IsValid(text))
							{
								base.WndProc(ref m);
							}
						}
						break;
					default:
						base.WndProc(ref m);
						break;
				}
			}
			protected override void Dispose(bool disposing)
			{
				if( disposing )
				{
					if(components != null)
					{
						components.Dispose();
					}
				}
				base.Dispose( disposing );
			}
			private void NumericTextBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
			{
				if (Char.IsNumber(e.KeyChar) || 
					(this.AllowNegatives && e.KeyChar == Convert.ToChar("-")) || 
					(this.Precision > 0 && e.KeyChar == Convert.ToChar(".")) || 
					e.KeyChar == this.CurrencyChar)
				{
					string text = this.Text.Substring(0, this.SelectionStart) + e.KeyChar.ToString() + this.Text.Substring(this.SelectionStart + this.SelectionLength);
					if (!this.IsValid(text))
					{
						e.Handled = true;
					}
				}
				else if (!Char.IsControl(e.KeyChar))
				{
					e.Handled = true;
				}
			}
			private void NumericTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
			{
				if (this.Text.Length == 0)
				{
					this.Text = this.FormatText("0");
				}
				else if (this.IsValid(this.Text))
				{
					this.Text = this.FormatText(this.Text);
				}
				else
				{
					e.Cancel = true;
				}
			}
		}
	}

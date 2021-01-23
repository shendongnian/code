	[DefaultBindingProperty("Text")]
	[DefaultProperty("Text")]
	[DefaultEvent("ValueChanged")]
	public class SpecializedTextBox : TextBox
	{
		private bool _allowNegativeSign = false;
		public bool AllowNegativeSign
		{
			get { return _allowNegativeSign; }
			set { _allowNegativeSign = value; }
		}
		public decimal? DecimalValue
		{
			get
			{
				decimal k;
				if (decimal.TryParse(this.Text, out k))
					return k;
				else
					return null;
			}
			set
			{
				if (value.HasValue)
					this.Text = value.Value.ToString();
				else
					this.Text = "";
			}
		}
		private void This_TextChanged(object sender, EventArgs e)
		{
			string s = base.Text;
			int cursorpos = base.SelectionStart;
			bool separatorfound = false;
				for (int i = 0; i < s.Length; )
				{
					if (char.IsNumber(s[i]))
						i++;
					else if (AllowNegativeSign && i < System.Globalization.CultureInfo.CurrentUICulture.NumberFormat.NegativeSign.Length && s.StartsWith(System.Globalization.CultureInfo.CurrentUICulture.NumberFormat.NegativeSign))
						i++;
					else if (!separatorfound && s[i].ToString() == System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator)
					{
						separatorfound = true;
						i++;
					}
					else
					{
						s = s.Remove(i, 1);
						if (i < cursorpos)
							cursorpos--;
					}
				}
			if (base.Text != s)
			{
				base.Text = s;
				base.SelectionStart = cursorpos;
				base.SelectionLength = 0;
			}
			if (ValueChanged != null)
				ValueChanged(this, EventArgs.Empty);
		}
		public event EventHandler ValueChanged;
		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// SpecializedTextBox
			// 
			this.TextChanged += new System.EventHandler(this.This_TextChanged);
			this.ResumeLayout(false);
		}
		public SpecializedTextBox()
			: base()
		{
			InitializeComponent();
        }
    }

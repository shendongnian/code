    using System;
    using System.Windows.Forms;
    using System.Globalization;
    using System.Diagnostics;
    using System.ComponentModel;
    
    /// <summary>
    /// Implements a <see cref="NumericUpDown"/> with leading and trailing symbols.
    /// </summary>
    public class NumericUpDownEx : NumericUpDown
    {
        /// <summary>
        /// Initializes a new instance of <see cref="NumericUpDownEx"/>.
        /// </summary>
        public NumericUpDownEx()
        { }
        private string _leadingSign = "";
        private string _trailingSign = "";
        
        /// <summary>
        /// Gets or sets a leading symbol that is concatenate with the text.
        /// </summary>
        [Description("Gets or sets a leading symbol that is concatenated with the text.")]
        [Browsable(true)]
        [DefaultValue("")]
        public string LeadingSign
        {
            get { return _leadingSign; }
            set { _leadingSign = value; this.Invalidate(); }
        }
        /// <summary>
        /// Gets or sets a trailing symbol that is concatenated with the text.
        /// </summary>
        [Description("Gets or sets a trailing symbol that is concatenated with the text.")]
        [Browsable(true)]
        [DefaultValue("")]
        public string TrailingSign
        {
            get { return _trailingSign; }
            set { _trailingSign = value; this.Invalidate(); }
        }
        protected override void UpdateEditText()
        {
            if (UserEdit)
            {
                ParseEditText();
            }
            ChangingText = true;
            base.Text = _leadingSign + GetNumberText(this.Value) + _trailingSign;
            Debug.Assert(ChangingText == false, "ChangingText should have been set to false");
        }
        private string GetNumberText(decimal num)
        {
            string text;
            if (Hexadecimal)
            {
                text = ((Int64)num).ToString("X", CultureInfo.InvariantCulture);
                Debug.Assert(text == text.ToUpper(CultureInfo.InvariantCulture), "GetPreferredSize assumes hex digits to be uppercase.");
            }
            else
            {
                text = num.ToString((ThousandsSeparator ? "N" : "F") + DecimalPlaces.ToString(CultureInfo.CurrentCulture), CultureInfo.CurrentCulture);
            }
            return text;
        }
        protected override void ValidateEditText()
        {
            ParseEditText();
            UpdateEditText();
        }
        protected new void ParseEditText()
        {
            Debug.Assert(UserEdit == true, "ParseEditText() - UserEdit == false");
            try
            {
                string text = base.Text;
                if (!string.IsNullOrEmpty(_leadingSign))
                {
                    if (text.StartsWith(_leadingSign))
                        text = text.Substring(_leadingSign.Length);
                }
                if (!string.IsNullOrEmpty(_trailingSign))
                {
                    if (text.EndsWith(_trailingSign))
                        text = text.Substring(0, text.Length - _trailingSign.Length);
                }
                if (!string.IsNullOrEmpty(text) &&
                    !(text.Length == 1 && text == "-"))
                {
                    if (Hexadecimal)
                    {
                        base.Value = Constrain(Convert.ToDecimal(Convert.ToInt32(text, 16)));
                    }
                    else
                    {
                        base.Value = Constrain(decimal.Parse(text, CultureInfo.CurrentCulture));
                    }
                }
            }
            catch
            {
                
            }
            finally
            {
                UserEdit = false;
            }
        }
        private decimal Constrain(decimal value)
        {
            if (value < base.Minimum)
                value = base.Minimum;
            
            if (value > base.Maximum)
                value = base.Maximum;
            
            return value;
        }
    }

    public class NumericTextBox : TextBox
    {
        #region Formato
        private string previousText = "";
        private bool ApplyingFormat = false;
        private CultureInfo _CI = new CultureInfo(CultureInfo.CurrentCulture.LCID,true);
        public CultureInfo CI
        {
            get { return _CI; }
            set { _CI = value; }
        }
        
        private int _DecimalPlaces = 0;
        /// <summary>
        /// Numero de plazas decimales 
        /// </summary>
        public int DecimalPlaces
        {
            get { return _DecimalPlaces; }
            set { _DecimalPlaces = value; _CI.NumberFormat.NumberDecimalDigits = value; }
        }
        public Decimal DecimalValue = 0;
        private string _DecimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        public string DecimalSeparator
        {
            get { return _DecimalSeparator; }
            set { _DecimalSeparator = value; _CI.NumberFormat.NumberDecimalSeparator = _DecimalSeparator; }
        }
        
        //public string DecimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        #endregion 
        
        public NumericTextBox()
        {
            HorizontalContentAlignment = HorizontalAlignment.Right;
            DataObject.AddPastingHandler(this, OnPaste);
        }
     
        private void OnPaste(object sender, DataObjectPastingEventArgs dataObjectPastingEventArgs)
        {
            var isText = dataObjectPastingEventArgs.SourceDataObject.GetDataPresent(System.Windows.DataFormats.Text, true);
            if (isText)
            {
                var text = dataObjectPastingEventArgs.SourceDataObject.GetData(DataFormats.Text) as string;
                if (IsTextValid(text))
                {
                    return;
                }
            }
            dataObjectPastingEventArgs.CancelCommand();
        }
        private bool IsTextValid(string enteredText)
        {
            //  If keyboard insert key is in toggled mode, and the actual insert point is Decimalseparator, we must avoid to overwrite it
            if (SelectionStart == this.Text.IndexOf(DecimalSeparator)
                & System.Windows.Input.Keyboard.GetKeyStates(System.Windows.Input.Key.Insert) == System.Windows.Input.KeyStates.Toggled)
            {
                SelectionStart += 1;
            }
            if (!enteredText.All(c => Char.IsNumber(c) || c == DecimalSeparator.ToCharArray()[0] || c == '-'))
            {
                return false;
            }
            //We only validation against unselected text since the selected text will be replaced by the entered text
            var unselectedText = this.Text.Remove(SelectionStart, SelectionLength);
            if ( enteredText == DecimalSeparator && unselectedText.Contains(DecimalSeparator))
            {
                //  Before return false, must move cursor beside Decimal separator
                SelectionStart = this.Text.IndexOf(DecimalSeparator) + 1;
                return false;
            }
            if (enteredText == "-" && unselectedText.Length > 0)
            {
                return false;
            }
            return true;
        }
        private bool ApplyFormat(TextChangedEventArgs e)
        {
            if (!ApplyingFormat)
            {
                ApplyingFormat = true;
                int SelectionStartActual = SelectionStart;
                string FinallText = this.Text;
                if (!FinallText.Contains(DecimalSeparator) & DecimalPlaces > 0)
                {
                    FinallText = String.Format("{0}{1}{2}", this.Text, DecimalSeparator, new string('0', DecimalPlaces));
                }
                bool state = Decimal.TryParse(FinallText, NumberStyles.AllowCurrencySymbol | NumberStyles.AllowDecimalPoint | NumberStyles.AllowTrailingSign, _CI, out DecimalValue);
                DecimalValue = Math.Round(DecimalValue, DecimalPlaces);
                if (DecimalValue == 0)
                {
                    FinallText = "";
                }
                else
                {
                    if (FinallText != DecimalValue.ToString(_CI))
                    {
                        FinallText = DecimalValue.ToString(_CI);
                    }
                }
                if (FinallText != this.Text)
                {
                    this.Text = FinallText;
                    SelectionStart = SelectionStartActual;
                }
                previousText = this.Text;
                ApplyingFormat = false;
                return state;
            }
            else
            {
                return true;
            }
        }
        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            e.Handled = !ApplyFormat(e);
            base.OnTextChanged(e);
        }
        protected override void OnPreviewTextInput(System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !IsTextValid(e.Text);
            base.OnPreviewTextInput(e);
        }
    }

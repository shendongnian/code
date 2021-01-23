    /*
     * the necessary usings:
     * using System.Globalization;
     * using System.Windows;
     * using System.Windows.Controls;
     * using System.Windows.Input;
     * using System.Threading;
     * And don't forget to change the currency settings on the XAML
     * or in the defaults (on the contructor)
     * It's set by default to Brazilian Real (R$)
     */
    public class CurrencyTextBox : TextBox
    {
        public CurrencyTextBox()
        {
            CurrencySymbol = "R$ ";
            CurrencyDecimalPlaces = 2;
            DecimalSeparator = ",";
            ThousandSeparator = ".";
            Culture = "pt-BR";
        }
        public string CurrencySymbol { get; set; }
        private int CurrencyDecimalPlaces { get; set; }
        public string DecimalSeparator { get; set; }
        public string ThousandSeparator { get; set; }
        public string Culture { get; set; }
        private bool IsValidKey(int k)
        {
            return (k >= 34 && k <= 43) //digits 0 to 9
                || (k >= 74 && k <= 83) //numeric keypad 0 to 9
                || (k == 2) //back space
                || (k == 32) //delete
                ;
        }
        private string Format(string text)
        {
            string unformatedString = text == string.Empty ? "0,00" : text; //Initial state is always string.empty
            unformatedString = unformatedString.Replace(CurrencySymbol, ""); //Remove currency symbol from text
            unformatedString = unformatedString.Replace(DecimalSeparator, ""); //Remove separators (decimal)
            unformatedString = unformatedString.Replace(ThousandSeparator, ""); //Remove separators (thousands)
            decimal number = decimal.Parse(unformatedString) / (decimal)Math.Pow(10, CurrencyDecimalPlaces); //The value will have 'x' decimal places, so divide it by 10^x
            unformatedString = number.ToString("C", CultureInfo.CreateSpecificCulture(Culture));
            return unformatedString;
        }
        private decimal FormatBack(string text)
        {
            string unformatedString = text == string.Empty ? "0.00" : text;
            unformatedString = unformatedString.Replace(CurrencySymbol, ""); //Remove currency symbol from text
            unformatedString = unformatedString.Replace(ThousandSeparator, ""); //Remove separators (thousands);
            CultureInfo current = Thread.CurrentThread.CurrentUICulture; //Let's change the culture to avoid "Input string was in an incorrect format"
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(Culture);
            decimal returnValue = decimal.Parse(unformatedString);
            Thread.CurrentThread.CurrentUICulture = current; //And now change it back, cuz we don't own the world, right?
            return returnValue;
        }
        private void ValueChanged(object sender, TextChangedEventArgs e)
        {
            // Keep the caret at the end
            this.CaretIndex = this.Text.Length;
        }
        private void MouseClicked(object sender, MouseButtonEventArgs e)
        {
            // Prevent changing the caret index
            e.Handled = true;
            this.Focus();
        }
        private void MouseReleased(object sender, MouseButtonEventArgs e)
        {
            // Prevent changing the caret index
            e.Handled = true;
            this.Focus();
        }
        private void KeyReleased(object sender, KeyEventArgs e)
        {
            this.Text = Format(this.Text);
            this.Value = FormatBack(this.Text);
        }
        private void KeyPressed(object sender, KeyEventArgs e)
        {
            if (IsValidKey((int)e.Key))
                return;
            e.Handled = true;
            this.CaretIndex = this.Text.Length;
        }
        private void PastingEventHandler(object sender, DataObjectEventArgs e)
        {
            // Prevent/disable paste
            e.CancelCommand();
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            DataObject.AddCopyingHandler(this, PastingEventHandler);
            DataObject.AddPastingHandler(this, PastingEventHandler);
            this.CaretIndex = this.Text.Length;
            this.KeyDown += KeyPressed;
            this.KeyUp += KeyReleased;
            this.PreviewMouseDown += MouseClicked;
            this.PreviewMouseUp += MouseReleased;
            this.TextChanged += ValueChanged;
            this.Text = Format(string.Empty);
        }
        public decimal? Value
        {
            get { return (decimal?)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value",
            typeof(decimal?),
            typeof(CurrencyTextBox),
            new FrameworkPropertyMetadata(new decimal?(), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(ValuePropertyChanged)));
        private static void ValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((CurrencyTextBox)d).Value = ((CurrencyTextBox)d).FormatBack(e.NewValue.ToString());
        }
    }

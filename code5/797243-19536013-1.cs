    public class TextBoxInputBehavior : Behavior<TextBox>
    {
        const NumberStyles validNumberStyles = NumberStyles.AllowDecimalPoint |
                                                   NumberStyles.AllowThousands |
                                                   NumberStyles.AllowLeadingSign;
        public TextBoxInputBehavior()
        {
            this.InputMode = TextBoxInputMode.None;
            this.JustPositivDecimalInput = false;
        }
        public TextBoxInputMode InputMode { get; set; }
        
        public static readonly DependencyProperty JustPositivDecimalInputProperty =
         DependencyProperty.Register("JustPositivDecimalInput", typeof(bool),
         typeof(TextBoxInputBehavior), new FrameworkPropertyMetadata(false));
        public bool JustPositivDecimalInput
        {
            get { return (bool)GetValue(JustPositivDecimalInputProperty); }
            set { SetValue(JustPositivDecimalInputProperty, value); }
        }
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.PreviewTextInput += AssociatedObjectPreviewTextInput;
            AssociatedObject.PreviewKeyDown += AssociatedObjectPreviewKeyDown;
            DataObject.AddPastingHandler(AssociatedObject, Pasting);
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.PreviewTextInput -= AssociatedObjectPreviewTextInput;
            AssociatedObject.PreviewKeyDown -= AssociatedObjectPreviewKeyDown;
            DataObject.RemovePastingHandler(AssociatedObject, Pasting);
        }
        private void Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                var pastedText = (string)e.DataObject.GetData(typeof(string));
                if (!this.IsValidInput(this.GetText(pastedText)))
                {
                    System.Media.SystemSounds.Beep.Play();
                    e.CancelCommand();
                }
            }
            else
            {
                System.Media.SystemSounds.Beep.Play();
                e.CancelCommand();
            }
        }
        private void AssociatedObjectPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                if (!this.IsValidInput(this.GetText(" ")))
                {
                    System.Media.SystemSounds.Beep.Play();
                    e.Handled = true;
                }
            }
        }
        private void AssociatedObjectPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!this.IsValidInput(this.GetText(e.Text)))
            {
                System.Media.SystemSounds.Beep.Play();
                e.Handled = true;
            }
        }
        private string GetText(string input)
        {
            var txt = this.AssociatedObject;
            int selectionStart = txt.SelectionStart;
            if (txt.Text.Length < selectionStart) 
                selectionStart = txt.Text.Length;
            int selectionLength = txt.SelectionLength;
            if (txt.Text.Length < selectionStart + selectionLength) 
                selectionLength = txt.Text.Length - selectionStart;
            var realtext = txt.Text.Remove(selectionStart, selectionLength);
            int caretIndex = txt.CaretIndex;
            if (realtext.Length < caretIndex) 
                caretIndex = realtext.Length;
            var newtext = realtext.Insert(caretIndex, input);
            return newtext;
        }
        private bool IsValidInput(string input)
        {
            switch (InputMode)
            {
                case TextBoxInputMode.None:
                    return true;
                case TextBoxInputMode.DigitInput:
                    return CheckIsDigit(input);
                case TextBoxInputMode.DecimalInput:
                    decimal d;
                    //wen mehr als ein Komma
                    if (input.ToCharArray().Where(x => x == ',').Count() > 1)
                        return false;
                    if (input.Contains("-"))
                    {
                        if (this.JustPositivDecimalInput) 
                            return false;
                        //minus einmal am anfang zulässig
                        if (input.IndexOf("-",StringComparison.Ordinal) == 0  && input.ToCharArray().Count(x=>x=='-') == 1)
                            return true;
                    }
                   
                    var result = decimal.TryParse(input, validNumberStyles, CultureInfo.CurrentCulture, out d);
                    return result;
                    
                    
                    
                default: throw new ArgumentException("Unknown TextBoxInputMode");
            }
            return true;
        }
        private bool CheckIsDigit(string wert)
        {
            return wert.ToCharArray().All(Char.IsDigit);
        }
    }
    public enum TextBoxInputMode
    {
        None,
        DecimalInput,
        DigitInput
    }

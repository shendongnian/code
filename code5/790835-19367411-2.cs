    public class myCustomRichEditWithIconBars
    {
        public override void OnApplyTemplate() 
        {
            // get part and store in _textField; 
            // bind rich text content field to filepath using converter.
            // this can be done in the xaml of your control too.
        }
        public String filePath {...}
        private RichText _textField {...}
    }

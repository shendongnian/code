    public class TooltipTextBox : TextBox {
        private string _text;
        public new string Text {
            get { return _text; }
            set
            {
                _text = value;
                this.ToolTip = value;
            }
        }
    }

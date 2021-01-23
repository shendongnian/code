    public class TooltipTextBox : TextBox {
        public new string Text {
            get { return base.Text; }
            set
            {
                base.Text = value;
                this.ToolTip = value;
            }
        }
    }

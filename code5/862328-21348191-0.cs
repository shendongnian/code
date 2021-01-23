    using System;
    namespace UpperCaseTextBox
    {
        public class UpperCaseTextBox : System.Windows.Forms.TextBox
        {
            protected override void OnTextChanged(EventArgs e)
            {
                var selectionStart = this.SelectionStart;
                var selectionLength = this.SelectionLength;
                this.Text = this.Text.ToUpper();
                this.SelectionStart = selectionStart;
                this.SelectionLength = selectionLength;
                base.OnTextChanged(e);
            }
        }
    }

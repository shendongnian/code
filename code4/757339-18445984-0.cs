    using System;
    using System.Windows.Forms;
    
    class CalculatorButton : Button, IMessageFilter {
        public string Digit { get; set; }
    
        protected override void OnClick(EventArgs e) {
            var box = lastFocused as TextBoxBase;
            if (box != null) {
                box.AppendText(this.Digit);
                box.SelectionStart = box.Text.Length;
                box.Focus();
            }
            base.OnClick(e);
        }
        protected override void OnHandleCreated(EventArgs e) {
            if (!this.DesignMode) Application.AddMessageFilter(this);
            base.OnHandleCreated(e);
        }
        protected override void OnHandleDestroyed(EventArgs e) {
            Application.RemoveMessageFilter(this);
            base.OnHandleDestroyed(e);
        }
    
        bool IMessageFilter.PreFilterMessage(ref Message m) {
            var focused = this.FindForm().ActiveControl;
            if (focused != null && focused.GetType() != this.GetType()) lastFocused = focused;
            return false;
        }
        private Control lastFocused;
    }

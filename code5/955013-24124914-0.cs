    public class MyTextBox : TextBox {
        private string originalText = null;
        public MyTextBox()
            : base() {
        }
        public bool TextModified {
            get {
                if (this.OriginalText != this.Text) return true;
                return false;
            }
        }
        public string OriginalText {
            get { return this.originalText; }
            internal set { this.originalText = value; }
        }
        public void SetText(string text) {
            this.Text = text;
            this.OriginalText = text;
        }
    }

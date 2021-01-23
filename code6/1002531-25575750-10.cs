    public class SpecialTextBox : RichTextBox
    {
        bool suppressInitialSetText = true;
        public SpecialTextBox()
        {
            BackColor = System.Drawing.Color.ForestGreen;
            AppendText("Initial Text...");
            this.VisibleChanged += new EventHandler(SpecialTextBox_VisibleChanged);
        }
        void SpecialTextBox_VisibleChanged(object sender, EventArgs e)
        {
            // Just in case, once the control becomes visible disable the kludge.
            if (Visible)
                suppressInitialSetText = false;
        }
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                if (!suppressInitialSetText || !string.IsNullOrEmpty(value) || Parent != null)
                    base.Text = value;
                suppressInitialSetText = false;
            }
        }
    }

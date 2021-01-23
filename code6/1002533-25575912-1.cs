        class SpecialTextBox : System.Windows.Forms.RichTextBox
        {
            public SpecialTextBox()
            {
                BackColor = System.Drawing.Color.ForestGreen;
                AppendText("Initial Text...");
                Text += "and some more initial text.";
            }
        }

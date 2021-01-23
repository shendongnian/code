        // flag for holding the Dirty state of the textbox
        private bool IsDirty = false;
        // the setter handles the showing or no showing of a * in the title
        private bool Dirty
        {
            set
            {
                IsDirty = value;
                this.Text = "TextProcessor " + (IsDirty ? "*" : "");
            }
        }
        // hookup textChanged on the (rich)textBox to trigger the Dirty flag
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            Dirty = true;
        }
        // hookup the formclosing event to Cancel the closing of the form.
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsDirty)
            {
                switch (MessageBox.Show("save?", "saving", MessageBoxButtons.YesNoCancel))
                {
                    case DialogResult.Cancel:
                    case DialogResult.Yes:
                        e.Cancel = true;
                        break;
                    default:
                        break;
                }
            }
        }

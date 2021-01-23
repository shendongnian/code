        public static DialogResult Show(string prompt, bool hideInput, out string userInput, Form parent = null, Form enable = null)
        {
            InputBoxForm frm = new InputBoxForm(prompt, hideInput);
            if (enable != null)
            {
                frm.Load += delegate { enable.Enabled = true; };
            }
            if (parent != null)
                frm.ShowDialog(parent);
            else
                frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                userInput = frm.txtInput.Text;
                frm.Dispose();
                return DialogResult.OK;
            }
            else
            {
                userInput = "";
                frm.Dispose();
                return DialogResult.Cancel;
            }
        }

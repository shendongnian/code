    using System;
    using System.Windows.Forms;
    namespace Namespace
    {
        class CustomTextBox : TextBox
        {
            string _text;
            public CustomTextBox()
            {
                this.Multiline = true;
                this.Wordwrap = true;
				this.KeyDown += new KeyEventHandler(CustomTextBox_KeyDown);
				this.KeyPress += new KeyPressEventHandler(CustomTextBox_KeyPress);
            }
			void CustomTextBox_KeyPress(object sender, KeyPressEventArgs e)
			{
				if (e.KeyChar == '+')
					e.Handled = true;
				else
					_text = _text + e.KeyChar.ToString();
			}
			void CustomTextBox_KeyDown(object sender, KeyEventArgs e)
			{
				if (e.KeyCode == Keys.Enter)
					e.Handled = true;
				else if (e.KeyCode == Keys.Add)
					_text = _text + @"+";
				this.Text = _text;
			}
        }
    }

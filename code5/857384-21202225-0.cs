     private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
                {
                    e.Handled = true;
                    string st = Clipboard.GetText();
                    richTextBox1.Text = st;
                }
                base.OnKeyDown(e);
            }
   
     private void richTextBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.V) { e.IsInputKey = true; }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
            {
            e.SuppressKeyPress = TextBox2Currency((TextBox)sender, e.KeyValue);
            }
        private bool TextBox2Currency(TextBox sender,int keyval)
            {
            if ((keyval >= 48 && keyval <= 58) || keyval == 46 || keyval == 8)
                {
                int pos = sender.SelectionStart;
                int oriLen = sender.Text.Length;
                string currTx = sender.Text.Replace(".", "").ToCurrency();
                int modLen = currTx.Length;
                if (modLen != oriLen)
                    pos += (modLen - oriLen);
                sender.Text = currTx;
                if ( pos>=0)
                    sender.SelectionStart = pos;
                return false;
                }
            return true;
            }

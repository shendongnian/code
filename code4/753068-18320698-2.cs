        string lastword;
        private void KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                lastword = ReadBack(rtb.SelectionStart);
            }
        }
        private string ReadBack(int start)
        {
            string builder = "";
            for (int x = start; x >= 0; x--)
            {
                Char c = rtb.Text[x];
                if (c == ' ')
                    break;
                builder += c;
            }
            Array.Reverse(builder.ToArray());
            return builder;
        }

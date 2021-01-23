    Dictionary<string,Color> dict = new Dictionary<string,Color>(StringComparer.CurrentCultureIgnoreCase);
    dict.Add(client.NetworkName,Color.Red);
    //you can add more pairs
    //build the pattern whenever you finish adding more entries to your dict    
    string pattern = string.Format("(?i)({0})",string.Join("|",dict.Select(el=>el.Key).ToArray()));
    [DllImport("user32")]
    private static extern int SendMessage(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam);
    //TextChanged event handler for your richTextBox1
    private void richTextBox1_TextChanged(object sender, EventArgs e) {
            int currentIndex = richTextBox1.SelectionStart;
            int currentSelectionLength = richTextBox1.SelectionLength;
            //BeginUpdate
            SendMessage(richTextBox1.Handle, 0xb, IntPtr.Zero, IntPtr.Zero);
            var matches = Regex.Matches(richTextBox1.Text, pattern);
            richTextBox1.SelectAll();
            richTextBox1.SelectionColor = Color.Black;
            foreach (Match m in matches)
            {
                richTextBox1.SelectionStart = m.Index;
                richTextBox1.SelectionLength = m.Length;
                richTextBox1.SelectionColor = dict[m.Value];
            }
            richTextBox1.SelectionStart = currentIndex;
            richTextBox1.SelectionLength = currentSelectionLength;
            //EndUpdate
            SendMessage(richTextBox1.Handle, 0xb, new IntPtr(1), IntPtr.Zero);            
            richTextBox1.Invalidate();
    }
    

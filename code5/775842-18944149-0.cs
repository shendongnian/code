        internal void SendChat(Color color, string from, string message)
        {
            if (rtbChat.InvokeRequired)
            {
                rtbChat.Invoke(new MethodInvoker(() => SendChat(color, from, message)));
                return;
            }
            string Text = String.Format("[{0}] {1}: {2}", DateTime.Now.ToString("t"), from, message);
            rtbChat.AppendText(Text);//Append text to rtbChat.
            //To speed up searching and highlighting text,its better to limit it to current line.
            int line = rtbChat.GetLineFromCharIndex(rtbChat.SelectionStart);//Get current line's number.
            string currenttext = rtbChat.Lines[line];//Get text of current line.
            Match match = Regex.Match(currenttext, message);//Find a match of the message in current text.
            if (match.Success)//If  message is found.
            {
                int position = rtbChat.SelectionStart;//Store caret's position before modifying it manually.
                rtbChat.Select(match.Index + rtbChat.GetFirstCharIndexFromLine(line), match.Length);//Select the match.
                rtbChat.SelectionColor = color;//Apply color code.
                rtbChat.SelectionStart = position;//Restore caret's position.
            }
            rtbChat.Text += Environment.NewLine;//Append a new line after each operation.
        }

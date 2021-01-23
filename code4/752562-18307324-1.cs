    String[] txt = richTextBox1.Lines;
                richTextBox1.Text = string.Empty;
                bool flag = false;
                for (int i = 0; i < txt.Length; i++)
                {
                    if (txt[i].StartsWith("ALTER TABLE") && txt[i].Contains("MOVE STORAGE"))
                        flag = true;
                    if (string.IsNullOrEmpty(txt[i]))
                        flag = false;
    
                    if (!flag)
                        richTextBox1.Text += txt[i] + "\r\n";
                }

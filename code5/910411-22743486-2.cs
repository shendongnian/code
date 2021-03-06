        private void button4_Click(object sender, EventArgs e)
        {
            string unique = Guid.NewGuid().ToString(); 
            richTextBox1.SelectionStart = 0;
            richTextBox1.SelectionLength = 0;
            richTextBox1.SelectedText = unique;
            int pos1 = richTextBox1.Rtf.IndexOf(unique);
            if (pos1 >= 0)
            {
                string header = richTextBox1.Rtf.Substring(0, pos1);
                string body = richTextBox1.Rtf.Substring(pos1);
                string[] lines = body.Split(new string[] { "\\par" }, StringSplitOptions.None);
                string lastFormat = "";
                Array.Sort(lines);
                StringBuilder sb = new StringBuilder();
                SortedList<string, string> rtfLines = new SortedList<string, string>();
                foreach (string line in lines)
                    {
                        string line_ = line.Replace("\r\n", "").Replace(unique, "").Trim();
                        if (line_[0] != '\\' ) rtfLines.Add(line_.Trim(), lastFormat + " " + line);
                        else
                        {
                            int pos2 = line_.IndexOf(' ');
                            if (pos2 < 0) rtfLines.Add(line_.Trim(), line);
                            else
                            {
                                rtfLines.Add(line_.Substring(pos2).Trim(), line);
                                lastFormat = line_.Substring(0, pos2);
                            }
                        }
                    }
                foreach (string key in rtfLines.Keys) if (key!="}") sb.Append(rtfLines[key]  + "\\par");
                richTextBox2.Rtf = header + sb.ToString();
            }
        }

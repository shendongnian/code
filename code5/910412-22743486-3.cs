        private void button4_Click(object sender, EventArgs e)
        {
            string unique = Guid.NewGuid().ToString() ; 
            richTextBox1.SelectionStart = 0;
            richTextBox1.SelectionLength = 0;
            richTextBox1.SelectedText = unique;
            int pos1 = richTextBox1.Rtf.IndexOf(unique);
            if (pos1 >= 0)
            {
                string header = richTextBox1.Rtf.Substring(0, pos1);
                string header1 = "";
                string header2 = "";
                int pos0 = header.LastIndexOf('}') + 1;
                if (pos0 > 1) { header1 = header.Substring(0, pos0); header2 = header.Substring(pos0); }
                // after the header comes a string of formats to start the document
                string[] formats = header2.Split('\\');
                string firstFormat = "";
                string lastFormat = "";
                // we extract a few important character formats (bold, italic, underline, font, color)
                // to keep with the first line which will be sorted away
                // the lastFormat variable holds the last formatting encountered
                // so we can add it to all lines without formatting
                // (and of course we are really talking about paragraphs)
                foreach (string fmt in formats)  
                    if (fmt[0]=='b' ||  ("cfiu".IndexOf(fmt[0]) >= 0 && fmt.Substring(0,2)!="uc") ) 
                          lastFormat += "\\" + fmt; else firstFormat += "\\" + fmt;
                // add the rest to the header
                header = header1 + firstFormat;
                // now we remove our marker from the body and split it into paragraphs
                string body = richTextBox1.Rtf.Substring(pos1);
                string[] lines = body.Replace(unique, "").Split(new string[] { "\\par" }, StringSplitOptions.None);
                StringBuilder sb = new StringBuilder();
                // the soteredlist will contain the unformatted text as key and the formatted one as valaue
                SortedList<string, string> rtfLines = new SortedList<string, string>();
                foreach (string line in lines)
                    {
                        // cleanup
                        string line_ = line.Replace("\r\n", "").Trim();
                        if (line_[0] != '\\' ) rtfLines.Add(line_, lastFormat + " " + line);
                        else
                        {
                            int pos2 = line_.IndexOf(' ');
                            if (pos2 < 0) rtfLines.Add(line_, line);
                            else
                            {
                                rtfLines.Add(line_.Substring(pos2).Trim(), line);
                                lastFormat = line_.Substring(0, pos2);
                            }
                        }
                    }
                foreach (string key in rtfLines.Keys) if (key != "}") sb.Append(rtfLines[key] + "\\par");
                richTextBox2.Rtf = header + sb.ToString();
            }

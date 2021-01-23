    void CopyAction(object sender, EventArgs e)
            {
                Clipboard.SetText(richTextBox1.SelectedText);
            }
    
            void PasteAction(object sender, EventArgs e)
            {
                if (Clipboard.ContainsText())
                {
                    richTextBox1.Text
                        += Clipboard.GetText(TextDataFormat.Text).ToString();
                }
            }  

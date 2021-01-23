        private Dictionary<string, string> fDic; //This must be instantiated in the initialization
        //Add this method to every Leave event in all text box controls.
        private void textBox_Leave(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;
             //Check if the text changed
            if (text != null)
            {
                if (fDic.ContainsKey((string)text.Tag))
                {
                    if (fDic[(string)text.Tag] != text.Text && !string.IsNullOrWhiteSpace(text.Text))
                        fDic[(string)text.Tag] = text.Text;
                }
                else if(!string.IsNullOrWhiteSpace(text.Text) != null)
                {
                    fDic[(string)text.Tag] = text.Text;
                }
                else if (string.IsNullOrWhiteSpace(text.Text)
                    fDic.Remove((string)text.Tag);
            }
        }

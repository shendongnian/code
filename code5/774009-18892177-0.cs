     private string GetTextBoxStrings()
            {
                string richTextString = string.Empty;
                List<KeyValuePair<string, string>> TextBoxList = new List<KeyValuePair<string, string>>();
    
                foreach (Control c in this.Controls)
                {
                    if (c is TextBox)
                    {
                        TextBoxList.Add(new KeyValuePair<string, string>(((TextBox)c).Name,((TextBox)c).Text));
                    }
                }
                TextBoxList = TextBoxList.OrderBy(x => x.Key).ToList();
    
                foreach (var item in TextBoxList)
                {
                    richTextString += item.Value + "\t:\t";
                }
                return richTextString;
            }

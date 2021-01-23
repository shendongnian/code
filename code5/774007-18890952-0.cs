    yourRichTextBox.Text = string.Join("\r\n",
                           yourForm.Controls.OfType<TextBox>()
                                   .Where(t=> {
                                       int i;
                                       if(int.TryParse(t.Name.Replace("textbox",""), out i)){
                                         return i <= 10 && i > 0;
                                       }                         
                                       return false;              
                                    }).Select(t=>label1.Text + "\t:\t" + t.Text));

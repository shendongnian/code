        private void testfunktion(string from, string to) 
        {  
            Control[] matches = this.Controls.Find(from, true);
            if (matches.Length > 0 && matches[0] is CheckBox)
            {
                CheckBox CB = (CheckBox)matches[0];
                matches = this.Controls.Find(to, true);
                if (matches.Length > 0 && matches[0] is CheckedListBox)
                {
                    CheckedListBox CLB = (CheckedListBox)matches[0];
                    for (int i = 0; i < CLB.Items.Count; i++)
                    {
                        CLB.SetItemChecked(i, CB.Checked);
                    }    
                }
            }
        }

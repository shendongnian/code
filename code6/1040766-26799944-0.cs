                    String items = "";
                    string SQLString = "";
                    if (this.subjects_listbox.CheckedItems.Count != 0)
                    {
                        for (int i = 0; i < this.subjects_listbox.Items.Count; i++)
                        {
                            items += this.subjects_listbox.CheckedItems[i].ToString() + "+";
                        }
                    } 
                    String[] subNames = items.Split('+');
                    foreach (var item in subNames)
                    {
                        MessageBox.Show(item); 
                    }

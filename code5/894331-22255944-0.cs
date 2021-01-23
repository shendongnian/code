            foreach (var item in checkedListBox1.CheckedItems)
            {
                Properties.Settings.Default.CheckedItems += item; ;
            }
            Properties.Settings.Default.Save();

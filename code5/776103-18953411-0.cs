     string[] array = { DropDownListType.SelectedItem.Text, txtDescription.Text };
            List<string> list = new List<string>();
            list.Add(array[0]);
            foreach(var value in list)
            {
                ListViewItem lvi = new ListViewItem(value);
                       ListViewDesc.Items.Add(lvi);
            }

            if (listBox1.SelectedItem != null)
            {
                string itemText = listBox1.SelectedItem.ToString();
                contextmenucontact.name = itemText;
                MessageBox.Show(contextmenucontact.name);
            }

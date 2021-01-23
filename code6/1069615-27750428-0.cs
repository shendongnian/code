            if (listBox1.SelectedItem != null)
            {
                string itemText = listBox1.SelectedItem.ToString();
                contextmenucontact = (contactsclass)itemText;
                MessageBox.Show(contextmenucontact.name);
            }

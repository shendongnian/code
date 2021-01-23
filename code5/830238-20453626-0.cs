    private void editContact()
    {
       using(Window1 win = new Window1("edit"))
       {
          DatabaseHandler handler = new DatabaseHandler();
          List<Contact> listie = handler.GetContactList();
          var selected = listview_contacts.SelectedItem as Contact;
          win.textbox_id.Text = selected.cId.ToString();
          win.textbox_name.Text = selected.Name.ToString();
          win.textbox_address.Text = selected.Address.ToString();
          win.textbox_email.Text = selected.Email.ToString();
          win.textbox_name.Focus();
          win.textbox_name.SelectionStart = win.textbox_name.Text.Length;
          win.ShowDialog();
          // do something with whatever win1 did.
          // if its say OK Cancrl form
          // if (win.ShowDialog() == DialogResult.OK) { // do something }
       }
    }

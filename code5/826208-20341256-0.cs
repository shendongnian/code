    private void txt_Search_KeyDown(object sender, KeyEventArgs e)
    {
       if (e.KeyCode == Keys.Enter) //apply your search only when pressing ENTER key
         {
           // you do your search as it was before 
           // i personally don't have suggestions here
           if (!txt_Search.AutoCompleteCustomSource.Contains(txt_Search.Text)) txt_Search.AutoCompleteCustomSource.Add(txt_Search.Text);
           //the line above will save all your searched contacts and display it in a beautiful format
         }
       else if (txt_Search.Text == "")
         {
           LoadContacts();
           RefreshAll();
         }
    }

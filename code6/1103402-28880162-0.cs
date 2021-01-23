    protected void ListBoxPersoner_SelectedIndexChanged(object sender, EventArgs e)
        {
           Person p = new Person();
           p.Fornamn = ListBoxPersoner.SelectedItem.ToString();       
            TextBoxFornamn.Text = p.Fornamn;
        }

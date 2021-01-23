    var query = db.Swims;
    // ID overrides all others, since it is unique no point adding more filters unless
    // you want to not return the row if the other filters don't match?
    if (IdTextBox.Text.Length > 0)
    {
        int id = Convert.ToInt32(IdTextBox.Text);
        query = query.Where(s => s.Id == id);
    }
    else
    {
        if (FirstNameTextBox.Text.Length > 0)
        {
            query = query.Where(s => s.FirstName.Contains(FirstNameTextBox.Text));
        }
        if (LastNameTextBox.Text.Length > 0)
        {
            query = query.Where(s => s.LastName.Contains(LastNameTextBox.Text));
        }
        if (PhoneTextBox.Text.Length > 0)
        {
            query = query.Where(s => s.Phone.Contains(PhoneTextBox.Text));
        }
    }
    GridView1.DataSource = query.ToList();

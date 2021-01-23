    using (Entities c = new Entities())
    {
        string sFirst = c.UserProfiles.Where(u => u.Id == selectedItemId).First().First.ToString();
        string sLast = c.UserProfiles.Where(u => u.Id == selectedItemId).First().Last.ToString();
        txtFirst.Text = sFirst;
        txtSecond.Text = sLast;
    }

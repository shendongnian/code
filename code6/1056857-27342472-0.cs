    foreach (object obj in array)
    {
        if (obj is Member)
        {
            Member m = (Member)obj;
            txtBoxEmail.Text = m.Email;
            txtBoxPhone.Text = m.Phone.ToString();
            txtBoxUsername.Text = m.Username;
        }
        else if (obj is Consoles)
        {
            Consoles c = (Consoles)obj;
            cmbConsole.Text = c.ConsoleName;
        }
        else if (obj is Advert)
        {
            Advert a = (Advert)obj;
            cmbGenre.Text = a.Genre;
            lblDateStarted.Text = a.Date.ToString("dd/MM/yyyy");
            txtBoxPrice.Text = a.Price.ToString();
            txtBoxName.Text = a.Name;
            txtBoxDesc.Text = a.Description;
        }
    }

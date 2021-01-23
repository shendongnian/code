    private void btnAdd_Click(object sender, EventArgs e)
    {
        profiles.Add(new Profile
        {
            NameAttribute = txtProfile.Text,
            Name = txtName.Text,
            Age = Convert.ToInt32(txtAge.Text),
            Country = txtCountry.Text
        });
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        var player = SomePlayerRepository.GetPlayer(User.Identity.Name);
        txtFirstName.Text = player.FirstName;
        // etc.
    }

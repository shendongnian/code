    private Character player = new Character();
    public Attribute(Character player)
    {
        this.player = player;
    }
    ...
    Character player = new Character(firstTextbox.Text);
    Attribute ChooseYourAttr = new Attribute(player);
    ...
    private void attributeTopLabel_Initialized(object sender, EventArgs e)
    {
        String welcomeAttribute = "Ahh. I see! So " + player.GetName();
        attributeTopLabel.Content = welcomeAttribute;
    }

    private string name = string.Empty;
    public Attribute(string name)
    {
        this.name = name;
    }
    ...
    Character Player = new Character(firstTextbox.Text);
    Attribute ChooseYourAttr = new Attribute(Player.getName());
    ...
    private void attributeTopLabel_Initialized(object sender, EventArgs e)
    {
        String welcomeAttribute = "Ahh. I see! So " + name;
        attributeTopLabel.Content = welcomeAttribute;
    }

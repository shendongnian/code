    public static void UseDropdown(Dropdown type)
    {
        if (type is Dropdown.Gifts)
        {
            if (type == Dropdown.Gifts.GreetingCards)
            {
                DoStuff();
            }
        }
        else if (type is Dropdown.GraphicsAndDesign)
        {
        }
    }

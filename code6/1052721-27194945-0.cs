    var buttonsToRemove = PanelNewFriend.Controls
                                    .OfType<Button>()
                                    .Where(x=> x.Tag == "0")
                                    .ToArray();//Take a copy
    foreach (Button item in buttonsToRemove)
    {
        PanelNewFriend.Controls.Remove(item);
    }

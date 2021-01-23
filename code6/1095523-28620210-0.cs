    if (isPaused)
    {
        foreach (var button in ButtonList)
        {
            if (MenuScreen == button.Parent)
            {
                button.Update(true);
            }
            else 
                button.Update(false);
        }
    }

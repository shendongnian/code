    private Screen IsVisibleOnScreen(Rectangle rect)
    {
        foreach (Screen screen in Screen.AllScreens)
        {
            if (screen.WorkingArea.IntersectsWith(rect))
            {
                return Screen;
            }
        }
    
        return null;
    }

    public static void ResetBackStack(this Frame frame)
    {
        PageStackEntry mainPage = frame.BackStack.Where(b => b.SourcePageType == typeof(YourPageType)).FirstOrDefault();
        frame.BackStack.Clear();
        if (mainPage != null)
        {
            frame.BackStack.Add(mainPage);
        }
    }

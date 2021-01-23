    public static void ResetBackStack(this Frame frame)
    {
        PageStackEntry mainPage = frame.BackStack.Where(b => b.SourcePageType == typeof(YourPageType)).FirstOrDefault();
        App.DefaultContent.MainFrame.BackStack.Clear();
        if (mainPage != null)
        {
            App.DefaultContent.MainFrame.BackStack.Add(mainPage);
        }
    }

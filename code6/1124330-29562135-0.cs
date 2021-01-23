    public static void ResetBackStack(this Frame frame)
    {
        // Get the first page from the navigation Stack, if present
        PageStackEntry mainPage = frame.BackStack.Where(b => b.SourcePageType.Equals(typeof(YourPageType))).FirstOrDefault();
        frame.BackStack.Clear();
        if (mainPage != null)
        {
            // Adds the PageStackEntry to the BackStack
            frame.BackStack.Add(mainPage);
        }
    }

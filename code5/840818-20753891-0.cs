    while (currentMessagesCount <= previousMessagesCount)
    {
        userMessagesList = driver.FindElementsByCssSelector(PostLocators.userPostsList_CssSelector);
        currentMessagesCount = userMessagesList.Count();
        System.Threading.Thread.Sleep(100);
    }

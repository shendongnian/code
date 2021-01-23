    async Task SendSomeKeys()
    {
      await Task.Delay(250);
      SendKeys.Send("{TAB}");
      await Task.Delay(250);
      SendKeys.Send("{TAB}");
      await Task.Delay(250);
      SendKeys.Send("{TAB}");
      await Task.Delay(250);
      SendKeys.Send("{ENTER}");
    }

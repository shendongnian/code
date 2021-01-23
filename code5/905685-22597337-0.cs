    var text_input = Driver.Instance.FindElement(By.Id("text_input"));
    if (!String.IsNullOrEmpty(text_input.GetAttribute("value"))) {
        var button_Save = Driver.Instance.FindElement(By.Id("submit"));
        button_Save.Click();
    } else {
        // if you want to do something
    }

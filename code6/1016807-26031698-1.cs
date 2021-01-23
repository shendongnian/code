    private void takeAction(string keyData, string locator, string action)
    {
       string key = string.Format("{0}{1}", keyData, action);
    
       if(actions.ContainsKey(key))
       {
          ITestableAction action = actions[key]
          action.Execute(locator);
       }    
    }

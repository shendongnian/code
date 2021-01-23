    public void InternalStartup()
    {
        ((ButtonEvent)EventManager.ControlEvents["UpdateList"]).Clicked +=
          (s, e) => UpdateList_Clicked("Update", e.Source.CreateNavigator());
    }

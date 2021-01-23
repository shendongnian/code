		  public UITestControl genericControl(UITestControl parentWindow, String Property1, String Value1, String Property2, String Value2)
        {
            UITestControl control = new UITestControl(parentWindow);
            control.TechnologyName = "MSAA";
            control.SearchProperties.Add(Property1, Value1, Property2, Value2);
            return control;
        }

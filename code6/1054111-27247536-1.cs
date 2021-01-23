    public static void ListControls(ControlCollection controls, List<Control> controlsFound)
    {
        foreach (var control in controls)
        {
            if (control is IAttributeAccessor)
            {
                controlsFound.Add(control);
                ListControls(control.Controls, controlsFound);
            }
        }
    }

    public static void ListControls(ControlCollection controls, List<Control> controlsFound)
    {
        foreach (var control in controls)
        {
            if (control is IAttributeAccessor)
            {
                foundControls.Add(control);
                ListControls(control.Controls, controlsFound);
            }
        }
    }

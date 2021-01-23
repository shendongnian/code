    private WebControl FindAspControlByIdInControl(Control control, string id)
    {
        foreach (var childControl in control.Controls)
        {
            if (childControl.ID != null && childControl.ID.Equals(id, StringComparison.OrdinalIgnoreCase) && childControl is WebControl)
            {
                return (WebControl)childControl;
            }
            if (childControl.HasControls())
            {
                WebControl result = FindAspControlByIdInControl(childControl, id);
                if (result != null) return result;
            }
        }
        return null;
    }
 

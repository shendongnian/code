    private WebControl FindAspControlByIdInControl(WebControl control, string id)
    {
        foreach (Control childControl in control.Controls)
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
 

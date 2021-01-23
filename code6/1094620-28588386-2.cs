    private Control FindAspControlByIdInControl(Control control, string id)
    {
        foreach (Control childControl in control.Controls)
        {
            if (childControl.ID != null && childControl.ID.Equals(id, StringComparison.OrdinalIgnoreCase) && childControl is WebControl)
            {
                return childControl;
            }
            if (childControl.HasControls())
            {
                Control result = FindAspControlByIdInControl(childControl, id);
                if (result != null) return result;
            }
        }
        return null;
    }

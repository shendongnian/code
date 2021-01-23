    private string ElementFromCursor()
    {
        // Convert mouse position from System.Drawing.Point to System.Windows.Point.
        System.Windows.Point point = new System.Windows.Point(Cursor.Position.X, Cursor.Position.Y);
        AutomationElement element = AutomationElement.FromPoint(point);
        string autoIdString;
        object autoIdNoDefault = element.GetCurrentPropertyValue(AutomationElement.AutomationIdProperty, true);
        if (autoIdNoDefault == AutomationElement.NotSupported)
        {
               // TODO Handle the case where you do not wish to proceed using the default value.
        }
        else
        {
            autoIdString = autoIdNoDefault as string;
        }
        return autoIdString;
    }

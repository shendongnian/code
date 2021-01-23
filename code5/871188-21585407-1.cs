    bool IsEditing()
    {
        if (Globals.ThisAddIn.Application.Interactive == false)
            return false;
            try
            {
                Globals.ThisAddIn.Application.Interactive = false;
                Globals.ThisAddIn.Application.Interactive = true;
                }
                    catch (Exception e)
                {
                return true;
            }
        return false;
    }

    public static class ControlExtensions
    {
        public static Control FindControlRecursive(this Control theControl,
                                                   string theControlId)
        {
            if (theControl == null)
            {
                return null;
            }
            // Try to find the control at the current level
            var theControlToBeFound = theControl.FindControl(theControlId);
            if (theControlToBeFound == null)
            {
                // Search the children
                foreach (Control theChildControl in theControl.Controls)
                {
                    theControlToBeFound = FindControlRecursive(theChildControl,
                                                               theControlId);
                    if (theControlToBeFound != null)
                    {
                        break;
                    }
                }
            }
            return theControlToBeFound;
        }
    }

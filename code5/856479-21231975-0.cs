        private Control RecursiveFindControl(Control aRootControl, string aFindControlClientId)
        {
            if (aRootControl.ClientID == aFindControlClientId)
                return aRootControl;
            foreach (Control ctl in aRootControl.Controls)
            {
                Control foundControl = RecursiveFindControl(ctl, aFindControlClientId);
                if (foundControl != null)
                    return foundControl;
            }
            return null;
        }

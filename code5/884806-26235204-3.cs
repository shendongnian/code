        private static string getOperaUrlFromProcess(Process proc)
        {
            // find the automation element
            AutomationElement elm = AutomationElement.FromHandle(proc.MainWindowHandle);
            // manually walk through the tree, searching using TreeScope.Descendants is too slow (even if it's more reliable)
            AutomationElement elmUrlBar = null;
            try
            {
                var elm1 = elm.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, "Browser container"));
                if (elm1 == null) { return null; } 
                elmUrlBar = elm.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, "Address field"));
            }
            catch
            {
                // Chrome has probably changed something, and above walking needs to be modified. :(
                // put an assertion here or something to make sure you don't miss it
                return null;
            }
            // make sure it's valid
            if (elmUrlBar == null)
            {
                // it's not..
                return null;
            }
            // there might not be a valid pattern to use, so we have to make sure we have one
            AutomationPattern[] patterns = elmUrlBar.GetSupportedPatterns();
            if (patterns.Length == 1)
            {
                string ret = "";
                try
                {
                    ret = ((ValuePattern)elmUrlBar.GetCurrentPattern(patterns[0])).Current.Value;
                }
                catch { }
                if (ret != "")
                {
                    return ret;
                }
                return null;
            }
            return null;
        }

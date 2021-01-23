            private static void ClickAccept()
        {
            var hwnd = Win32.FindWindowsWithText("Toast").FirstOrDefault();
            if (hwnd == IntPtr.Zero)
                return;
            //Get parent window.
            AutomationElement element = AutomationElement.FromHandle(hwnd);
            //Get all descendants
            AutomationElementCollection elements = element.FindAll(TreeScope.Descendants, Condition.TrueCondition);
            //loop through descendants
            foreach (AutomationElement elementNode in elements)
            {
                if (elementNode.Current.Name == "Accept")
                {
                    object pattern;
                    if(elementNode.TryGetCurrentPattern(InvokePattern.Pattern, out pattern))
                    {
                        (pattern as InvokePattern).Invoke();
                        return;
                    }
                }
      
            }
        }    

    public static string GetOperaURL()
        {
            string url = "";
            Process[] procsOpera = Process.GetProcessesByName("opera");
            foreach (Process opera in procsOpera)
            {
                // the chrome process must have a window
                if (opera.MainWindowHandle == IntPtr.Zero)
                {
                    continue;
                }
                // find the automation element
                AutomationElement elm = AutomationElement.FromHandle(opera.MainWindowHandle);
                AutomationElement elmUrlBar = elm.FindFirst(TreeScope.Descendants,
                    new PropertyCondition(AutomationElement.NameProperty, "Address field"));
                // if it can be found, get the value from the URL bar
                if (elmUrlBar == null) continue;
                AutomationPattern pattern = elmUrlBar.GetSupportedPatterns().FirstOrDefault(wr=>wr.ProgrammaticName == "ValuePatternIdentifiers.Pattern");
                if (pattern == null) continue;
                ValuePattern val = (ValuePattern)elmUrlBar.GetCurrentPattern(pattern);
                url = val.Current.Value;
                break;
            }
            return url;
        }

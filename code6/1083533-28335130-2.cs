    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Windows.Automation;
    
    namespace FirefoxAutomation
    {
        class FirefoxAutomation
        {
            private const string FF_CLASSNAME = "MozillaWindowClass"; //"Firefox ClassName taken from Inspect";
            private const string FF_AUTOMATIONID = null;//"Firefox AutomationId taken from Inspect";
            private static readonly Regex FF_NAME = new Regex("( - Mozilla Firefox)$"); //new Regex("Firefox Name regex based on name taken from Inspect");
    
            private const string PROXY_CLASSNAME = "MozillaDialogClass";//"Proxy window ClassName taken from Inspect";
            private const string PROXY_AUTOMATIONID = null;//"Proxy window AutomationId taken from Inspect";
            private static readonly Regex PROXY_NAME = new Regex("^(Authentication Required)$");//new Regex("Proxy window Name regex based on name taken from Inspect");
    
            public FirefoxAutomation()
            {
                SubscribeTopLevelWindowOpened();
            }
    
            private void SubscribeTopLevelWindowOpened()
            {
                Automation.AddAutomationEventHandler(WindowPattern.WindowOpenedEvent,
                    AutomationElement.RootElement, TreeScope.Children, TopLevelWindowOpened);
            }
    
            private void TopLevelWindowOpened(object sender, AutomationEventArgs e)
            {
                var element = sender as AutomationElement;
                if (element == null) return;
    
                // Filter for FireFox window element
                if (!MatchWindow(element, FF_CLASSNAME, FF_AUTOMATIONID, FF_NAME)) return;
    
                // Subscribe for child window opened even
                Automation.AddAutomationEventHandler(WindowPattern.WindowOpenedEvent,
                    element, TreeScope.Children, FireFoxChildWindowOpened);
            }
    
            private void FireFoxChildWindowOpened(object sender, AutomationEventArgs e)
            {
                var element = sender as AutomationElement;
                if (element == null) return;
    
                // Filter for a proxy message
                if (!MatchWindow(element, PROXY_CLASSNAME, PROXY_AUTOMATIONID, PROXY_NAME)) return;
    
                // Find the cancel button
                var controls = element.FindAll(TreeScope.Children, Condition.TrueCondition).Cast<AutomationElement>().ToList();
                var cancelButton = controls.FirstOrDefault(c => c.Current.ControlType == ControlType.Button && c.Current.Name == "Cancel");
                if (cancelButton == null) return;
    
                // Get the click pattern
                object clickPatternObj;
                if (!cancelButton.TryGetCurrentPattern(InvokePattern.Pattern, out clickPatternObj)) return;
                ((InvokePattern)clickPatternObj).Invoke(); // click the cancel button
            }
    
            private bool MatchWindow(AutomationElement element, string className, string automationId, Regex name)
            {
                var current = element.Current;
                if (current.ControlType != ControlType.Window) return false;
                if (className != null && current.ClassName != className) return false;
                if (automationId != null && current.AutomationId != automationId) return false;
                if (name != null && name.IsMatch(current.Name)) return false;
                return true;
            }
        }
    }

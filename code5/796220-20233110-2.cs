    <pre>using InteropUIA = interop.UIAutomationCore;<code>
    
    <pre>if (senderElement.Current.ControlType.Equals(ControlType.Custom))
            {
                var automation = new InteropUIA.CUIAutomation();
                var element = automation.GetFocusedElement();
                var pattern = (InteropUIA.IUIAutomationLegacyIAccessiblePattern)element.GetCurrentPattern(10018);
                Logger.Info(string.Format("{0}: {1} - Selected", pattern.CurrentName, pattern.CurrentValue));
            }<code>

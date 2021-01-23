    public class DatePickerHelper : DatePicker
    {
        public void ClickTemplateButton()
        {
            base.ApplyTemplate();
            Button btn = (GetTemplateChild("DateTimeButton") as Button);
            ButtonAutomationPeer peer = new ButtonAutomationPeer(btn);
            IInvokeProvider provider = (peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider);
            provider.Invoke();
        }
    }    

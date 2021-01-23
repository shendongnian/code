    class CanvasAutomationPeer : FrameworkElementAutomationPeer
    {
        public CanvasAutomationPeer(Canvas owner)
            : base(owner) { }
        protected override AutomationControlType GetAutomationControlTypeCore()
        {
            return AutomationControlType.Custom;
        }
    }

    public class CustomLabel : Label
    {
        public bool isTooltipSet
        {
            get;
            set;
        }
    
        public void SetToolTip()
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this, string.Empty);
            isTooltipSet = true;
    
        }
    }

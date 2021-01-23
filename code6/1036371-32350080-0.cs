    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip)]
    public class ToolStripDateTimePicker : ToolStripControlHost
    {
        private FlowLayoutPanel controlPanel;
        private DateTimePicker picker = new DateTimePicker();
        public ToolStripDateTimePicker()
            : base(new FlowLayoutPanel())
        {
            controlPanel = (FlowLayoutPanel)base.Control;
            controlPanel.BackColor = Color.Transparent;
            AutoSize = false;
            controlPanel.Controls.Add(picker);
        }
 
        public DateTime Value
        {
            get { return this.picker.Value; }
            set { this.picker.Value = value; }
        }
 
        protected override void OnSubscribeControlEvents(Control control)
        {
            base.OnSubscribeControlEvents(control);
        }
 
        protected override void OnUnsubscribeControlEvents(Control control)
        {
            base.OnUnsubscribeControlEvents(control);
        }
    }

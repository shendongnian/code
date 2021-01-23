    class UserAction
    {
        public void SetControlsEnabled(bool value)
        {
            foreach (ISupportEnabled component in this.components)
            {
                component.Enabled = value;
            }
        }
        public bool Enabled
        {
            // ...
            set
            {
                this.SetControlsEnabled(value);
            }
        }
        private List<ISupportEnabled> components = new List<ISupportEnabled>();
        public void AddComponent(ISupportEnabled component)
        {
            if (!components.Contains(component))
            {
                components.Add(component);
            }
        }
    }
    public interface ISupportEnabled
    {
        bool Enabled { get; set; }
    }
    private class ControlAdapter : ISupportEnabled
    {
        private readonly Control control;
        public ControlAdapter(Control control)
        {
            this.control = control;
        }
        public bool Enabled
        {
            get { return control.Enabled; }
            set { control.Enabled = value; }
        }
    }
    private class ToolStripItemAdapter : ISupportEnabled
    {
        private readonly ToolStripItem toolStripItem;
        public ToolStripItemAdapter(ToolStripItem toolStripItem)
        {
            this.toolStripItem = toolStripItem;
        }
        public bool Enabled
        {
            get { return toolStripItem.Enabled; }
            set { toolStripItem.Enabled = value; }
        }
    }

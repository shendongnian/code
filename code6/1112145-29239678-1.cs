    class CompactFlowPanel : Panel, IExtenderProvider
    {
        public override System.Windows.Forms.Layout.LayoutEngine LayoutEngine
        {
            get
            {
                return CompactFlow.Instance;
            }
        }
        public bool CanExtend(object extendee)
        {
            Control control = extendee as Control;
            return control != null && control.Parent == this;
        }
    }

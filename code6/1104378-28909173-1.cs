    public class CustomColorTable : ProfessionalColorTable
    {
        //a bunch of other overrides...
        public override Color ToolStripBorder
        {
            get { return Color.FromArgb(0, 0, 0); }
        }
        public override Color ToolStripDropDownBackground
        {
            get { return Color.FromArgb(64, 64, 64); }
        }
        public override Color ToolStripGradientBegin
        {
            get { return Color.FromArgb(64, 64, 64); }
        }
        public override Color ToolStripGradientEnd
        {
            get { return Color.FromArgb(64, 64, 64); }
        }
        public override Color ToolStripGradientMiddle
        {
            get { return Color.FromArgb(64, 64, 64); }
        }
    }

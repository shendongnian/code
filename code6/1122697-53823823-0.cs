    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    
    namespace WindowsFormsApp
    {
        [Designer(typeof(ParentControlDesigner))]
        public class FlowLayoutPanelHeritable : FlowLayoutPanel
        {
        }
    }

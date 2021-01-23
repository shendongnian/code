    using System;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1() {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e) {
                var flowLayoutPanel = flowLayoutPanel1;
                ReorganizeFlowLayoutPanel(flowLayoutPanel);
            }
    
            private static void ReorganizeFlowLayoutPanel(FlowLayoutPanel flowLayoutPanel) {
                var controls = flowLayoutPanel.Controls.OfType<Control>().OrderBy(s => s.Width);
                var index = 0;
                foreach (var tuple in controls) {
                    flowLayoutPanel.Controls.SetChildIndex(tuple, index++);
                }
            }
        }
    }

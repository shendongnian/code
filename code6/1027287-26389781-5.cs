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
            var width = flowLayoutPanel.Width;
            var controls = flowLayoutPanel.Controls.OfType<Control>().ToList();
            var ascending = new List<Control>(controls.OrderBy(s => s.Width));
            var descending = new List<Control>(controls.OrderByDescending(s => s.Width));
            var list = new List<Control>();
            while (ascending.Count > 0) {
                Control smallest = ascending[0];
                ascending.RemoveAt(0);
                if (ascending.Count == 0) {
                    list.Add(smallest);
                    break;
                }
                foreach (var largest in descending) {
                    if (smallest.Width + largest.Width < width) {
                        list.Add(smallest);
                        list.Add(largest);
                        ascending.Remove(largest);
                        descending.Remove(largest);
                        descending.Remove(smallest);
                        break;
                    }
                }
            }
            var i = 0;
            foreach (var control in list) {
                flowLayoutPanel.Controls.SetChildIndex(control, i++);
            }
        }
    }

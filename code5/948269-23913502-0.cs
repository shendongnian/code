    public partial class Form1 : Form
    {
        private int location = 0;
        public Form1()
        {
            InitializeComponent();
            // Set position on top of your panel
            pnlPanel.AutoScrollPosition = new Point(0, 0);
            // Set maximum position of your panel beyond the point your panel items reach.
            // You'll have to change this size depending on the total size of items for your case.
            pnlPanel.VerticalScroll.Maximum = 280;
        }
        private void btnUp_Click(object sender, EventArgs e)
        {
            if (location - 20 > 0)
            {
                location -= 20;
                pnlPanel.VerticalScroll.Value = location;
            }
            else
            {
                // If scroll position is below 0 set the position to 0 (MIN)
                location = 0;
                pnlPanel.AutoScrollPosition = new Point(0, location);
            }
        }
        private void btnDown_Click(object sender, EventArgs e)
        {
            if (location + 20 < pnlPanel.VerticalScroll.Maximum)
            {
                location += 20;
                pnlPanel.VerticalScroll.Value = location;
            }
            else
            {
                // If scroll position is above 280 set the position to 280 (MAX)
                location = pnlPanel.VerticalScroll.Maximum;
                pnlPanel.AutoScrollPosition = new Point(0, location);
            }
        }
    }

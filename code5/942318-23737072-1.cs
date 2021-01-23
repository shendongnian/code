    public partial class Form1 : Form
    {
        private Color selected_color;
        private List<Color> colors;
        public Form1()
        {
            InitializeComponent();
            colors = new List<Color>();
            colors.Add(Color.Red);
            colors.Add(Color.Green);
            colors.Add(Color.Blue);
            colors.Add(Color.Yellow);
            tableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetDouble;
            for (byte i = 0; i < tableLayoutPanel.Controls.Count; i++)
            {
                Panel p = tableLayoutPanel.Controls[i] as Panel;
                p.BackColor = colors[i];
                p.Click += panel_click;
            }
        }
        private void panel_click(object sender, EventArgs e)
        {
            Panel p = sender as Panel;
            selected_color = p.BackColor;
            lbl_color.Text = selected_color.ToString();
            lbl_color.ForeColor = selected_color;
        }
    }

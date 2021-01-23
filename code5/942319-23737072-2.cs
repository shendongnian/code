    public partial class MainForm : Form
    {
        private Color selected_color;
        private List<Color> colors;
        public MainForm()
        {
            InitializeComponent();
            colors = new List<Color>();
            colors.Add(Color.Red);
            colors.Add(Color.Green);
            colors.Add(Color.Blue);
            colors.Add(Color.Yellow);
            colors.Add(Color.Teal);
            colors.Add(Color.RosyBrown);
            colors.Add(Color.Lime);
            colors.Add(Color.Gray);
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
        private void btn_showMoreColours_Click(object sender, EventArgs e)
        {
            Panel[] panels = new Panel[4];
            for (byte i = 0; i < panels.Length; i++)
            {
                panels[i] = new Panel();
                panels[i].Dock = DockStyle.Fill;
                panels[i].Location = new System.Drawing.Point(3, 3);
                panels[i].Name = "panel" + (i + 4);
                panels[i].Size = new System.Drawing.Size(123, 100);
                panels[i].BackColor = colors[i + 4];
                panels[i].Click += panel_click;
                tableLayoutPanel.Controls.Add(panels[i]);
            }
            Size = new Size(Size.Width, Size.Height * 2);
        }
    }

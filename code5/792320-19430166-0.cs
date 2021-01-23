    public partial class Form1 : Form
    {
        private TableLayoutPanel grid = new TableLayoutPanel();
        public Form1()
        {
            InitializeComponent();
            grid.RowCount = 9;
            for (int i = 1; i <= grid.RowCount; i++)
            {
                grid.RowStyles.Add(new RowStyle(SizeType.Percent, 42)); // all the same percent, the value doesn't matter
            }
            grid.ColumnCount = 16;
            for (int i = 1; i <= grid.ColumnCount; i++)
            {
                grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42)); // all the same percent, the value doesn't matter
            }
            grid.Dock = DockStyle.Fill;
            this.Controls.Add(grid);
            this.BackColor = Color.Black;
            ExampleGrid();
        }
        private void ExampleGrid()
        {
            grid.Controls.Clear();
            AddEntry("Today", 0, 1, 3, Color.White, Color.Black, false);
            AddEntry("| 14:00", 0, 4, 3, Color.White, Color.Black, false);
            AddEntry("| 14:30", 0, 7, 3, Color.White, Color.Black, false);
            AddEntry("| 15:00", 0, 10, 3, Color.White, Color.Black, false);
            AddEntry("| 15:30", 0, 13, 3, Color.White, Color.Black, false);
            AddEntry("050", 1, 0, 1, Color.White, Color.Black, false);
            AddEntry("BBC HD", 1, 1, 3, Color.White, Color.Black, false);
            AddEntry("Mary Poppins", 1, 4, 8, Color.Black, Color.White, true);
            AddEntry("Dustbin Baby -->", 1, 12, 4, Color.White, Color.LightGray, true);
            AddEntry("051", 2, 0, 1, Color.White, Color.Black, false);
            AddEntry("ITV1 HD", 2, 1, 3, Color.White, Color.Black, false);
            AddEntry("Rosemary and Thyme", 2, 4, 6, Color.White, Color.Gray, true);
            AddEntry("Agatha Christie's Poirot -->", 2, 10, 6, Color.White, Color.LightGray, true);
            AddEntry("052", 3, 0, 1, Color.White, Color.Black, false);
            AddEntry("Channel 4 HD", 3, 1, 3, Color.White, Color.Black, false);
            AddEntry("The Green Berets", 3, 4, 5, Color.White, Color.Gray, true);
            AddEntry("Coach Trip", 3, 9, 3, Color.White, Color.LightGray, true);
            AddEntry("Countdown -->", 3, 12, 4, Color.White, Color.LightGray, true); 
            // ... etc ...
        }
        private void AddEntry(string text, int row, int col, int columnSpan, Color foreColor, Color backColor, bool border)
        {
            Label lbl = new Label();
            lbl.Text = text;
            lbl.AutoSize = false;
            lbl.AutoEllipsis = true;
            lbl.ForeColor = foreColor;
            lbl.BackColor = backColor;
            lbl.Dock = DockStyle.Fill;
            lbl.BorderStyle = border ? BorderStyle.FixedSingle : BorderStyle.None;
            lbl.TextAlign = ContentAlignment.MiddleLeft;
            grid.Controls.Add(lbl, col, row);
            grid.SetColumnSpan(lbl, columnSpan);
        }
    }

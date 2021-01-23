    public partial class Form1 : Form
    {
        private List<List<Button>> grid = new List<List<Button>>();
        public Form1()
        {
            InitializeComponent();
            byte numRows = 5;
            byte numCols = 5;
            for (byte i = 0; i < numRows; i++)
            {
                grid.Add(ButtonRowCreator(numCols, 25, (i+1) * 50));
            }
        }
        public List<Button> ButtonRowCreator(byte numOfBtnsNeeded, int x, int y)
        {
            List<Button> btns = new List<Button>();
            for (int i = 0; i < numOfBtnsNeeded; i++)
            {
                Button btn = new Button();
                btn.Size = new Size(50, 50);
                btn.Location = new Point(x + (i * btn.Width), y);
                btns.Add(btn);
                this.Controls.Add(btn);
                btn.Click += new EventHandler(btn_Click);
            }
            return btns;
        }
        void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.Text = "X";
            int curRow = -1, curCol = -1;
            for(int i = 0; i < grid.Count; i++)
            {
                int index = grid[i].IndexOf(btn);
                if (index != -1)
                {
                    curRow = i;
                    curCol = index;
                    Console.WriteLine("curRow = " + curRow.ToString() + ", curCol = " + curCol.ToString());
                }
            }
            // ... now you can use "curRow", "curCol" and "grid" to do something ...
            // reset all BackColors:
            foreach (List<Button> row in grid)
            {
                foreach (Button col in row)
                {
                    col.BackColor = Button.DefaultBackColor;
                }
            }
            // the below should give you some examples for the 
            // syntax necessary to access buttons in the grid
            // highlight current row:
            foreach (Button col in grid[curRow])
            {
                col.BackColor = Color.Yellow;
            }
            // highlight current col:
            for (int i = 0; i < grid.Count; i++)
            {
                grid[i][curCol].BackColor = Color.Yellow;
            }
        }
    }

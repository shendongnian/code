      public Form1()
        {
            InitializeComponent();
    
            grid_db.DataSource = new[]
            {
                new{
                   id = 1,
                   tekst="a"
                    },
                    new
                        {
                            id=2,
                            tekst="b"
                        }
            }.ToList();
            grid_statement.DataSource = new[]
            {
                new{
                   id = 1,
                   tekst="b"
                    },
                    new
                        {
                            id=2,
                            tekst="c"
                        }
            }.ToList();
             Load += (sender, args) =>
                        {
                            HighlightRows();
                        };
        }
        private void HighlightRows()
        {
            int no_of_col = grid_db.Columns.Count;
            int j;
            var B = "";
            var A = "";
            for (j = 0; j < no_of_col; j++)
            {
                //if statement value is null replace with ZERO
                if (grid_statement.Rows[0].Cells[j].Value != null &&
                    !string.IsNullOrWhiteSpace(grid_statement.Rows[0].Cells[j].Value.ToString()))
                {
                    B = grid_statement.Rows[0].Cells[j].Value.ToString();
                }
                //if db value is null replace with zero
                if (grid_db.Rows[0].Cells[j].Value != null &&
                    !string.IsNullOrWhiteSpace(grid_db.Rows[0].Cells[j].Value.ToString()))
                {
                    A = grid_db.Rows[0].Cells[j].Value.ToString();
                }
                if (A != B)
                {
                    grid_db.Rows[0].Cells[j].Style.BackColor = Color.Red;
                    grid_statement.Rows[0].Cells[j].Style.BackColor = Color.Red;
                }
            }
        }

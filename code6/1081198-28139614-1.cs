        private void button1_Click(object sender, EventArgs e)
        {
            // figure these out from your file:
            int rows = 8;
            int cols = 5;
            // setup the TableLayoutPanel:
            InitTableLayoutPanel(tableLayoutPanel1, rows, cols);
        }
        private void InitTableLayoutPanel(TableLayoutPanel TLP, int rows, int cols)
        {
            TLP.RowCount = rows;
            TLP.RowStyles.Clear();
            for (int i = 1; i <= rows; i++)
            {
                TLP.RowStyles.Add(new RowStyle(SizeType.Percent, 1));
            }
            TLP.ColumnCount = cols;
            TLP.ColumnStyles.Clear();
            for (int i = 1; i <= cols; i++)
            {
                TLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1));
            }
        }

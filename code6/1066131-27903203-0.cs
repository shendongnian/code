    private void Form1_Load(object sender, EventArgs e)
        {
            Thread ReceiveThread = new Thread(new ThreadStart(ReceiveUDPData));
            comboBox1.Items.Add("04 : Read Input Registers");
            ReceiveThread.IsBackground = true;
            ReceiveThread.Priority = ThreadPriority.Highest;
            ReceiveThread.Start();
            Control.CheckForIllegalCrossThreadCalls = false;
            dt.Columns.Add("Index");
            dt.Columns.Add("Data");
            for (int j = 0; j < 125; j++)
            {
                DataRow row = dt.NewRow();
                row[0] = j;
                row[1] = 0;
                dt.Rows.Add(row);
            }
            dataGridView.DataSource = dt;
        }
    public void UpdateGridView(byte[] valueArray)
        {
            for (int j = 0; j < valueArray.Length; j++)
            {
                DataRow row = dt.Rows[j];
                row["Index"] = j+1; 
                row["Data"] = valueArray[j];
            }
        }

    private void button1_Click(object sender, EventArgs e)
    {
      for(int i = 0; i < 10; i++)
      {
        DataGridViewRow newRow = new DataGridViewRow();
        this.dataGridView1.Rows.Add(newRow);
      }
   
      FillThread[] t = new FillThread[3];
    
      for (int i = 0; i < 3; i++)
      {
        t[i] = new FillThread(this.dataGridView1, i);
      }
    }
    class FillThread
    {
        struct param_t
        {
            public DataGridView TheGrid;
            public int Type;
        }
        private Thread _worker;
        
        
        public FillThread(DataGridView theGrid, int type)
        {
            _worker = new Thread(ThreadProc);
            param_t param = new param_t();
            param.TheGrid = theGrid;
            param.Type = type;
            _worker.Start(param);
        }
        public void ThreadProc(object data)
        {
            param_t param = (param_t)data;
            for(int i = 0; i < 10; i++)
            {
                param.TheGrid.Rows[i].Cells[param.Type].Value = i;
            }
        }
    }

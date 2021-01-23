    private void btnButton_Click(object sender, EventArgs e)
    {
        timer = new System.Threading.Timer(new TimerCallback(PoolingStart));
        timer.Change(0, 100);
    }
    public void PoolingStart(object state)
    {
        this.dgvGrid.Invoke(new MethodInvoker(() => { this.dgvGrid.Rows.Add(new DataGridViewRow()); }));            
    }

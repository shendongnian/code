    BindingSource bs = new BindingSource();
    BindingList<DataTable> tables = new BindingList<DataTable>();
    protected override void OnLoad(EventArgs e) {
      base.OnLoad(e);
      int counter = 0;
      DataTable dt = null;
      foreach (DataRow dr in tblTicketDetail.Rows) {
        if (counter == 0) {
          dt = tblTicketDetail.Clone();
          tables.Add(dt);
        }
        dt.Rows.Add(dr.ItemArray);
        ++counter;
        if (counter > 9) {
          counter = 0;
        }
      }
      bindingNavigator1.BindingSource = bs;
      bs.DataSource = tables;
      bs.PositionChanged += bs_PositionChanged;
      bs_PositionChanged(bs, EventArgs.Empty);
    }
    void bs_PositionChanged(object sender, EventArgs e) {
      dataGridView1.DataSource = tables[bs.Position];
    }

      pnlLorries.Controls.Clear();
      DateTime dt_start = monthView1.SelectionStart;
      DateTime dt_end = monthView1.SelectionEnd;
      int rowCounter = 0;
      for (DateTime dt = dt_start; dt.Date <= dt_end; dt = dt.AddDays(1))
      {
        Label lbl = new Label();
        Font ft = new System.Drawing.Font("Calibri", 12);
        lbl.Text = dt.ToShortDateString();
        lbl.Font = ft;
        pnlLorries.Controls.Add(lbl, 0, rowCounter);
        rowCounter++;
        FlowLayoutPanel pnl = new FlowLayoutPanel();
        pnl.Dock = DockStyle.Fill;
        pnl.AutoSize = true;
        DataTable tbl = cDALSettings.DB.GetCannedTable("select * from lorry");
        // Now we simply add these controls to the panel...
        foreach (DataRow row in tbl.Rows)
        {
          ucLorryDay ld = new ucLorryDay(dt, cTypes.ToInt(row["id"]), this);
          pnl.Controls.Add(ld);
        }
        pnlLorries.Controls.Add(pnl, 0, rowCounter);
        rowCounter++;
      }

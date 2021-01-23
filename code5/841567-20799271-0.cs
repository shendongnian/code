    private void xrTableCell4_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e) {
      var id = this.GetCurrentColumnValue<int>("ID"); // get value of field ID for this row
      var lines = GetRows(id); // for demo only: returns string[]
      (sender as XRLabel).Lines = lines;
    }

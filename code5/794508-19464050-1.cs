    var matchedRow = productList.Rows.OfType<DataGridViewRow>()
                                .FirstOrDefault(row=>row.Cells[0].Value != null &&
                                                     row.Cells[0].Value.Equals(itemInfo[0]));
    if(matchedRow != null){
      int qty = (int)matchedRow.Cells[6].Value + 1;
      double price = (double)matchedRow.Cells[3].Value;
      matchedRow.Cells[7].Value = price * qty;
    }

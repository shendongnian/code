     // ws.Cells[Rowstart, ColStart, RowEnd, ColEnd]
      ws.Cells[1, 1].Value = "BILL OF MATERIALS";
      ws.Cells[1, 1, 1, 7].Merge = true; //Merge columns start and end range
      ws.Cells[1, 1, 1, 7].Style.Font.Bold = true; //Font should be bold
      ws.Cells[1, 1, 1, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Alignment is center
      ws.Cells[1, 1, 1, 7].Style.Font.Size = 25;

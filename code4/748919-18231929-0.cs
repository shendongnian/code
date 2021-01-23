          bool LeftUntagged = false;
          Excel.Workbook RawExcel = Globals.ThisAddIn.Application.ActiveWorkbook;
          Excel.Worksheet sheet = null;
          Excel.Range matrix = sheet.UsedRange;
          for (int x = 1; x <= matrix.Rows.Count; x++)
          {
              for (int y = 1; y <= matrix.Columns.Count; y++)
              {
                  string CellColor = sheet.Cells[x, y].Interior.Color.ToString(); //Here I go double value which is converted to string.
                  if (sheet.Cells[x, y].Value != null && (CellColor == Color.Transparent.ToArgb().ToString() || **CellColor == Excel.XlRgbColor.rgbGold.GetHashCode().ToString()**))
                  {
                      sheet.Cells[x, y].Interior.Color = Color.Transparent;
                  }
              }
          }
      }

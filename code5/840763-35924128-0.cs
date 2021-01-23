    private List<List<String>> ExcelRangeToLists(Excel.Range cells)
    {
       return cells.Rows.Cast<Excel.Range>().AsParallel().Select(row =>
       {         
          return row.Cells.Cast<Excel.Range>().Select(cell =>
          {
             var cellContent = cell.Value2;
             return (cellContent == null) ? String.Empty : cellContent.ToString();                        
          }).Cast<string>().ToList();                
       }).ToList();
    });

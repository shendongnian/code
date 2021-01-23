    public class MyGrid : DataGridView {
      public MyGrid(string columnName, string columnHeader) {
        this.Columns.Add(columnName, columnHeader);
      }
    }

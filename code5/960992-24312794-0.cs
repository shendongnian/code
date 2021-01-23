    public class MyRowData { }
    public class MyCellData { }
    public class MyColumnData { }
    public static class Extender
    {
        static Dictionary<DataGridViewRow, MyRowData> dictRow = new Dictionary<DataGridViewRow, MyRowData>();
        static Dictionary<DataGridViewCell, MyCellData> dictCell = new Dictionary<DataGridViewCell, MyCellData>();
        static Dictionary<DataGridViewColumn, MyColumnData> dictColumn = new Dictionary<DataGridViewColumn, MyColumnData>();
        public static MyRowData GetMyRow(this DataGridViewRow row)
        {
            MyRowData myRow;
            if (dictRow.TryGetValue(row, out myRow))
                return myRow;
            return null;  // or throw error or return blank MyRow...
        }
        public static void SetMyRow(this DataGridViewRow row, MyRowData myRow)
        {
            dictRow[row] = myRow;
        }
    }

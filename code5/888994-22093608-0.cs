    using SCG = System.Collections.Generic;
    using System.Linq;
    public class Row {
       public int CheckedType { get; set; }
       public int CheckedFile { get; set; }
    }
    ...
    public delegate SCG.IEnumerable<Row> GetAllCheckedItemsDelegate();
    public bool GetAllCheckedItems() {  
       if (ListView.InvokeRequired) {
          var rows = ListView.Invoke(new GetAllCheckedItemsDelegate(GetAllCheckedItems)
                , new object[] {});
          return rows.Count() > 0;
       } else {
          var rows = new SCG.List<Row>();
          for (int i = 0; i < ListView.CheckedItems.Count; i++) {
             // create and set row 
             var row = new Row { CheckedType = x, CheckedFile = y };
             ...
             rows.Add(row);
          }
          return rows; 
       }
    }

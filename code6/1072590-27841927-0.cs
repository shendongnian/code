    public class TableSource : UITableViewSource {
        //  - - - -
         public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
            {
            var cell = tableView.GetCell(tableView, indexPath);
            var myCell class = cell as MyCellClass;
            if (myCell != null) {
                // TODO: do something with cell.
            }          
          }
        // - - - -
        }
    // - - - -
    }

    private class SimpleTableViewSource : UITableViewSource
    {
       // Some data. Item1 will serve as the Text and Item2 will be a value indicating whether the cell is selected or not
       private List<Tuple<string, bool>> Data { get; set; }
    
       public SimpleTableViewSource()
       {
           this.Data = new List<Tuple<string, bool>>() {
               Tuple.Create("Item 1", false),
               Tuple.Create("Item 2", false),
               Tuple.Create("Item 3", false),
               Tuple.Create("Item 4", false),
               Tuple.Create("Item 5", false),
               Tuple.Create("Item 6", false),
               Tuple.Create("Item 7", false)
           };
       }
    
       public override int RowsInSection(UITableView tableview, int section)
       {
           return this.Data.Count;
       }
    
       public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
       {
           UITableViewCell cell = tableView.DequeueReusableCell("cell") ?? new UITableViewCell();
    
           cell.TextLabel.Text = this.Data[indexPath.Row].Item1;
           
           // if the row is selected show checkmark
           if (this.Data[indexPath.Row].Item2)
           {
               cell.Accessory = UITableViewCellAccessory.Checkmark;
           }
           else
           {
               cell.Accessory = UITableViewCellAccessory.None;
           }
    
           return cell;
       }
    
       public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
       {
           UITableViewCell cell = tableView.DequeueReusableCell("cell") ?? new UITableViewCell();
           cell.Selected = !this.Data[indexPath.Row].Item2;
           this.Data[indexPath.Row] = Tuple.Create(this.Data[indexPath.Row].Item1, !this.Data[indexPath.Row].Item2);
           tableView.ReloadData();
       }    
    }

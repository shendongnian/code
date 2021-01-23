    public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
    {
        //some your code
 
        if(cell.ViewWithTag (99) != null)
        {
            cell.RemoveSubview(cell.ViewWithTag (99));
        }
        var textField = YourTextFields [elements.Where(e => e.Type == "textField").ToList().IndexOf(elements [indexPath.Row])];
        cell.AddSubview (textField);
        //some your code
    }

    public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath) {
    UITableViewCell cell = tableView.DequeueReusableCell (cellID);
    
    if (cell == null) {
        cell = new UITableViewCell (UITableViewCellStyle.Subtitle, cellID);
    }
    
    string firstValue = "Hello"
    string secondValue = "Bye"
    
    string[] concat = {firstValue, secondValue};
    
    foreach(string op in concat){
        cell.TextView.Text += op;
    }
    
    return cell;
    
    }

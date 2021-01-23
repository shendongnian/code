    public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
    {
        var section = Container.Root[indexPath.Section];
        var element = section[indexPath.Row];
        section.Remove(element);
        Container.Root.Reload(section, UITableViewRowAnimation.None);
    }

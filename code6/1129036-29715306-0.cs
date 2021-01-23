    var temp = new Dictionary<int,TreeNode>();
    foreach( var item in Items )
    {
        var node = new TreeNode()
        {
            Checked = item.Checked,
            Text = Item.LabelText
        };
        temp.Add( item.ID, node );
        if( item.ParentID == 0 )
            DropDown.Nodes.Add( node );
        else
            // TODO: make sure node.ParentId exists in temp here
            temp[node.ParentID].SubItems.Add( node );       
    }

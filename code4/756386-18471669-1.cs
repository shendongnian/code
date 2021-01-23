    Gtk.NodeStore store = new Gtk.NodeStore(typeof(MyTreeNode));
    store.AddNode(new MyTreeNode("The Beatles"));
    store.AddNode(new MyTreeNode("Peter Gabriel"));
    store.AddNode(new MyTreeNode("U2"));
    Gtk.CellRendererText editableCell = new Gtk.CellRendererText();
    Gtk.NodeView view = new Gtk.NodeView(store);
    view.AppendColumn ("Artist", editableCell, "text", 0);
    view.ShowAll();
    editableCell.Editable = true;
    editableCell.Edited += (object o, Gtk.EditedArgs args) => {
        var node = store.GetNode(new Gtk.TreePath(args.Path)) as MyTreeNode;
        node.Text = args.NewText;
    };

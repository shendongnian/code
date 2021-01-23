    var view = new Gtk.TreeView();
    var cell = new Gtk.CellRendererText();
    var col1 = new Gtk.TreeViewColumn();
    col1.Title = "Column 1"
    col1.PackStart(cell, true);
    col1.AddAttribute(cell, "text", 0);
    view.AppendColumn(col1);
    var model = new Gtk.ListStore(typeof(string));
    model.AppendValues("AAA");
    model.AppendValues("BBB");
    model.AppendValues("CCC");
    view.Model = model;
    // This is the selection changed handler: I use a lambda but
    // it is as easy to use a delegate `Changed` is a standard C#
    // event.
    view.Selection.Changed += (sender, e) => {
        Console.WriteLine("SELECTION WAS CHANGED");
        Gtk.TreeIter selected;
        if (view.Selection.GetSelected(out selected)) {
            Console.WriteLine("SELECTED ITEM: {0}", model.GetValue(selected, 0)));
        }
    };
    Gtk.TreeIter iter;
    if (model.GetIterFirst(out iter))
         view.Selection.SelectIter(iter);

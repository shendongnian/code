		// Create a column for the name
		Gtk.TreeViewColumn nameColumn = new Gtk.TreeViewColumn ();
		nameColumn.Title = "Name";
		// Create a column for the song title
		Gtk.TreeViewColumn sColumn = new Gtk.TreeViewColumn ();
		sColumn.Title = "Song Title";
		// Add the columns to the TreeView
		this.<NameOfYourNodeView>.NodeSelection.NodeView.AppendColumn(nameColumn);
		this.<NameOfYourNodeView>.NodeSelection.NodeView.AppendColumn(sColumn);
		// Create a model that will hold two strings -  Name and Song Title
		Gtk.ListStore mListStore = new Gtk.ListStore (typeof (string), typeof (string));
		// Assign the model to the TreeView
		this.<NameOfYourNodeView>.NodeSelection.NodeView.Model = mListStore;
		// Add some data to the store
		mListStore.AppendValues ("Garbage", "Dog New Tricks");
		// Create the text cell that will display the artist name
		Gtk.CellRendererText NameCell = new Gtk.CellRendererText ();
		// Add the cell to the column
		nameColumn.PackStart (NameCell, true);
		// Do the same for the song title column
		Gtk.CellRendererText sTitleCell = new Gtk.CellRendererText ();
		sColumn.PackStart (sTitleCell, true);
		// Tell the Cell Renderers which items in the model to display
		nameColumn.AddAttribute (NameCell, "text", 0);
		sColumn.AddAttribute (sTitleCell, "text", 1);

	if (ListView.GetItemAt(e.X, e.Y) != null )
	{
           ContextMenu1.Show(Cursor.Position);
	}
        else
	{
           ContextMenu2.Show(Cursor.Position);
	}

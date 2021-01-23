    private void GrdView_ShownEditor(object sender, EventArgs e)
    {
	  GridView view = (GridView)sender;
	  GrdView.FocusedRowHandle = view.FocusedRowHandle;
	  GrdView.FocusedColumn = GrdView.FocusedColumn;
	  GrdView.ShowEditor();
	  dynamic editor = GrdView.ActiveEditor;
	  //editor.Enabled = False
	  editor.BackColor = Color.Blue;
	  //view.Invalidate()
    }

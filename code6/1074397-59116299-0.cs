    private void ThisAddIn_Startup(object sender, EventArgs e){
	    Application.ActiveExplorer().SelectionChange += activeExplorer_SelectionChange;
    }
    private void activeExplorer_SelectionChange()
    {
        Selection selection = Application.ActiveExplorer().Selection;
        if (selection != null && selection.Count == 1 && selection[1] is MailItem)
        {
		    MailItem selectedMail = selection[1] as MailItem;
		    selectedMail.Read += SelectedMail_Read;
        }
    }
    private void SelectedMail_Read()
    {
	     Selection selection = Application.ActiveExplorer().Selection;
	     MailItem selectedMail = selection[1] as MailItem;
	     ...
    }

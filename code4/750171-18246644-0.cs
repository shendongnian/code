    AddItemView dialog;
    
    private void showWindow(object obj)
    {
    
        if ( dialog == null )
        {
           dialog = new AddItemView();
           dialog.Show();
           dialog.Owner = this;
           dialog.Closed += new EventHandler(AddItemView_Closed);
        }
        else
           dialog.Activate();
    }
    
    void AddItemView_Closed(object sender, EventArgs e)
        {
    
            dialog = null;
        }

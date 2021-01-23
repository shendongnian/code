    void onProblemDoubleClick(object sender, MouseButtonEventArgs e)
    {
     var item = sender as ListViewItem;
                if (item != null && item.IsSelected)                                         
                {
                   //here is your ProblemsListItem item           
                   var actualItem = (ProblemsListItem)item.Content;               
                }
    }

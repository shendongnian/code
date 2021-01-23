    private void ListView1_ItemCheck1(object sender, ItemCheckEventArgs e)
    {
        ListViewItem item = (ListViewItem)sender
        if (e.CurrentValue==CheckState.Unchecked)
        {
            Unsubscribe(e.Index, currentUserID);
              /*You can pass the Index of the ListViewItem that caused the event
              to a method that will update your database (I would find it easier
              to program a function that takes the current user's ID as a parameter)*/
            Unsubscribe(item.Name, currentUserID);
              /*OR this might be a better way for you to reference what subscription
              should be cancelled (again, in addition to a UserID)*/
        }
        else if((e.CurrentValue==CheckState.Checked))
        {
            Subscribe(e.Index, currentUserID);
        }
    }
    private void Unsubscribe(int index, int userID)
    {
        //unsubscribe the referenced userID from the subscription at index
    }
    private void Unsubscribe(string subscriptionName, int userID)
    {
        //unsubscribe the referenced userID from the subscription called subscriptionName
    }

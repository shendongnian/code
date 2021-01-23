    private async void RemoveButton_Click(object sender, RoutedEventArgs e)
    {
        GridViewItem selection = (GridViewItem)GridView1.SelectedItem;
        string ToBeDeleted = selection.Content.ToString();
        GridView1.Items.Remove(selection);
        SQLiteAsyncConnection conn = new SQLiteAsyncConnection("people");
        var query = conn.Table<Person>().Where(x => x.Name == ToBeDeleted);
        var result = await query.ToListAsync();
        foreach (var item in result)
        {
            await conn.DeleteAsync(item);
        }
        MessageDialog msgDialog = new MessageDialog("Category " + ToBeDeleted + " is deleted");
        msgDialog.ShowAsync();
    }

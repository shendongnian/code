    History.Selected_HistoryId = listitem.Id;
----------
    public void Delete_Click(object sender, EventArgs e)
    {
        Db_helper.DeleteContact(History.Selected_HistoryId);
    }

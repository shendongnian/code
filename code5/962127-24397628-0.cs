    var returnedCollection = App.db.Query(“select Email from Usuario”);
    for (int i = 0; i < returnedCollection.Count(); i++)
    {
    MessageBox.Show(returnedCollection[0].Email.ToString());
    }

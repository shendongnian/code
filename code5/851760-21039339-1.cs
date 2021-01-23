    void CellClickEvent(object sender, DataGridViewCellEventArgs e)
    {
     if(e.ColumnIndex == 1) // i'll take column 1 as a link
     {
      var link = datagridview1[e.columnindex, e.rowindex].Value;
      var id = datagridview1[0, e.rowindex].Value;
    
      DoSomeThingWithLink(link, id);
     }
    }
    void DoSomeThingWithLink(string link, int id)
    {
     var myDialog = new Dialog(link,id);
     myDialog.ShowDialog();
     myDialog.Dispose(); //Dispose object after you have used it
    }

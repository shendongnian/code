    List<string> keywordsarray = new List<string>();
    
    /*do something to fill your list with the keyword data*/
    
    DataTable books = new DataTable();
    DataTable searchresults = new DataTable();
    DataRow[] results;
    
     foreach (string keyword  in keywordsarray)
     {
        results = books.Select("BookTitle like '"+keyword+"' or BookDescription like'"+keyword+"'");
        foreach (DataRow dr in results)
        {
           searchresults.ImportRow(dr);
        }
     }
     //the grid view
     search.DataSource = searchresults;
     search.DataBind();

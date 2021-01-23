    DataTable books = new DataTable();
    DataRow[] results = default(DataRow[]); //initialized with default
    string[] keywordsarray = new string[] { "a", "b" }; //example
    books.Columns.Add("BookTitle"); //example added column
    books.Columns.Add("BookDescription"); //example added column
    books.AcceptChanges();
    books.Rows.Add("abc", "def"); //example added row
    books.Rows.Add("a", "c");   //example added row
    DataTable dtSearchResult = books.Clone();   //copy structure from source datatable
    foreach (var v in keywordsarray)
    {
        results = books.Select("BookTitle like '%" + v + "%' or BookDescription like '%" + v + "%'");
                
        foreach (DataRow dr in results)
        {
            //must be criteria here to check for duplicate rows in dtSearchResult.
            dtSearchResult.ImportRow(dr);
        }
    }          
            
    dtSearchResult.AcceptChanges();
     //the grid view
    search.DataSource = dtSearchResult;
    search.DataBind();

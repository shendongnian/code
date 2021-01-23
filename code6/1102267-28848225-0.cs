    string query = "SELECT * FROM [ItemMaster]"
    string whereClause = string.Empty;
    if(!string.IsNullOrEmpty(txtArticle.Text))
    {
        string.Concat(whereClause ," ARTICLE = @Article");
        //add parameter value for @Article
    } 
    if(!string.IsNullOrEmpty(txtPartnumber.Text))
    {
        string.Concat(whereClause ," PART_NUMBER = @Part_Number");
        //add parameter value for @Part_Number
    }
    if(!string.IsNullOrEmpty(txtSmn.Text))
    {
        string.Concat(whereClause ," SMN = @SMN");
        //add parameter value for @SMN
    }
    if(!string.IsNullOrEmpty(txtSmn.Text) || !string.IsNullOrEmpty(txtPartnumber.Text) || !string.IsNullOrEmpty(txtArticle.Text))
       string.concat(query," WHERE ",whereClause);

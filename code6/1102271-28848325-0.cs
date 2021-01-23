    string query = "SELECT * FROM [ItemMaster] Where 1 = 1 "
    
    if(!string.IsNullOrEmpty(txtArticle.Text))
    {
        string.Concat(query ,"AND ARTICLE = @Article ");
        //add parameter value for @Article
    } 
    if(!string.IsNullOrEmpty(txtPartnumber.Text))
    {
        string.Concat(query ,"AND PART_NUMBER = @Part_Number ");
        //add parameter value for @Part_Number
    }
    if(!string.IsNullOrEmpty(txtSmn.Text))
    {
        string.Concat(query ,"AND SMN = @SMN ");
        //add parameter value for @SMN
    }
    return query;

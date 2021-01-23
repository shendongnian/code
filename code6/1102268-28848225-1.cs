    string query = "SELECT * FROM [ItemMaster]"
    string whereClause = string.empty;
    bool andFlag = false;
    if(!string.IsNullOrEmpty(txtArticle.Text))
    {
        string temp = " ARTICLE = @Article";
        string.Concat(wherClause,temp);
        andFlag = true;
        //add parameter value for @Article
    } 
    if(!string.IsNullOrEmpty(txtPartnumber.Text))
    {
        string temp = string.Empty;
        if(andFlag)
             temp = " AND PART_NUMBER = @Part_Number";
        else 
            temp = " PART_NUMBER = @Part_Number";
        string.Concat(whereClause ,temp);
        //add parameter value for @Part_Number
    }
    if(!string.IsNullOrEmpty(txtSmn.Text))
    {
        string temp = string.Empty;
        if(andFlag)
             temp = " AND SMN = @SMN";
        else 
            temp = " SMN = @SMN";
        string.Concat(whereClause ,temp);
        //add parameter value for @SMN
    }
    if(!string.IsNullOrEmpty(txtSmn.Text) || !string.IsNullOrEmpty(txtPartnumber.Text) || !string.IsNullOrEmpty(txtArticle.Text))
       string.concat(query," WHERE ",whereClause);

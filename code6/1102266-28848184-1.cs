    private string getCondtionForSearch()
        {
            string condition = string.Empty;
            string whereCondition = string.Empty;
    
            // TODO same for all values
            if (!(string.IsNullOrEmpty(txtArticle.Text)))
            {
                whereCondition = whereCondition + '"ARTICLE = "' + txtArticle.Text + " AND ";
            }
    
            // TODO 1: cut last 5 chars (" AND ")
            // TODO 2: Add " WHERE " at the begin
            // TODO 3: Add whereCondition to your SQL 
            if (!String.IsNullOrEmpty(whereCondition))
            {
    
            }
            return condition;
        }

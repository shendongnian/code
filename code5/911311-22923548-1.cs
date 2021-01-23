    private void CreateRelations() {
        DataRelation relation = new DataRelation("CustDist",
            data.Tables["Customers"].Columns["Project Customer UBF Id"],
            data.Tables["Discounts"].Columns["Project Customer UBF Id"]);
        data.Relations.Add(relation);
       
        data.Tables["Customers"].Columns["Project Customer UBF Id"].AutoIncrement = true;
        data.Tables["Customers"].Columns["Project Customer UBF Id"].AutoIncrementSeed = -1;
        data.Tables["Customers"].Columns["Project Customer UBF Id"].AutoIncrementStep = -1;
    }

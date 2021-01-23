    public void UIMethod() {
        Task query1 = GetQuery();
        Task query2 = GetQuery2012();
    
        await Task.WhenAll(query1, query2); //will free the thread until both tasks complete
        MergeTables();
    }

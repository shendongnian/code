    public Stock GetStock(int id)
    {
        Stock stock;
        var sql = "select * from Stocks where Id = @id";
        using (var connection = ConnectionFactory.GetOpenConnection())
        {
            stock = connection.Query(sql, new { id }).Select(ConvertToStock).Single();
        }
        return stock;
    }

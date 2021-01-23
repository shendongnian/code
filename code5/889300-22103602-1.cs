    public List<Products> GetProducts()
    {
        using (var multi = new SqlConnection(ConfigurationManager.ConnectionStrings["name1"].ConnectionString).QueryMultiple("SPROC NAME", commandType: CommandType.StoredProcedure))
        {
            return multi.Read<Products>().ToList();
        }    
    }

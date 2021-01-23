    public List<Distribution> getDistributionAll()
    {
        List<Distribution> distributionAll = new List<Distribution>();
        using (var connection = new SqlConnection(FoodBankDB.GetConnectionString())) // get your connection string from the other class here
        {
            SqlCommand command = new SqlCommand("SELECT b.addressLineOne FROM dbo.Beneficiaries b INNER JOIN dbo.Distributions d ON d.beneficiary = b.id", connection);
            connection.Open();
            using (var dr = command.ExecuteReader())
            {
                while (dr.Read())
                {
                    string address = dr["addressLineOne"].ToString();
                    distributionAll.Add(new Distribution(address));
                }
            }
        }
        return distributionAll;
    }

    public static bool HasDeposit(int userId)
    {
        //since executeScalar is intended to retreive only a single value
        //from a query, we select the number of results instead of the email address
        //of each matching result.
        const string queryTransaction = "SELECT COUNT(UserID) FROM Transaction WHERE TransactionTypeID = 6 AND UserID = @UserID";
            
        var constr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            
        using (var con = new SqlConnection(constr))
        {
            using (var cmd = new SqlCommand(queryTransaction, con))
            {
                cmd.Parameters.AddWithValue("@UserID", userId);
                con.Open();
                var result = (int)cmd.ExecuteScalar();
                //returning a boolean comparator works like this :
                //will return true if the result is greater than zero, but false if it is not.
                return result > 0;
            }
        }
    }

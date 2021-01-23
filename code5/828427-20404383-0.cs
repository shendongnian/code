    public List<PaymentAccDetails> GetPaymentAccDetails()
    {
       var paymentAccDetailsList = new List<PaymentAccDetails>();
       using (var conn = new SqlConnection(/*ConnectionString*/))
       { 
            conn.Open();
            using (var cmd  = new SqlCommand("YourStoredProcedure", conn))
            {
                 cmd.CommandType = CommandType.StoredProcedure;
                 using (var reader = cmd.ExecuteReader())
                 {
                     while (reader.Read())
                     {
                         var paymentAccDetails = new PaymentAccDetails();
                         paymentAccDetails.PaymentMethod = Convert.ToString(row["PaymentMethod"]);
                         paymentAccDetails.AccountType = Convert.ToString(row["AccountType"]);
                         ... etc.
                         paymentAccDetailsList.Add(paymentAccDetails);
                     }
                 }
            }
        }
        return paymentAccDetailsList;
    }

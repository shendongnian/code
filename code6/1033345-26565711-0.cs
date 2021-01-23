    com.CommandText = "INSERT INTO newOrder (Order_No, Customer_No, Issue_Date, Delivery_Date, Order_Type,Total_Weight) Values(@1,@2,@3,@4,@5,@6);";
            com.Parameters.Add("@Order_No", OleDbType.Char, 1).Value = "1";
            com.Parameters.Add("@Customer_No", OleDbType.Char, 1).Value = "2";
            com.Parameters.Add("@Issue_Date", OleDbType.Char, 1).Value = "3";
            com.Parameters.Add("@Delivery_Date", OleDbType.Char, 1).Value = "4";
            com.Parameters.Add("@Order_Type", OleDbType.Char, 1).Value = "5";
            com.Parameters.Add("@Total_Weight", OleDbType.Char, 1).Value = "6";

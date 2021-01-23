            SqlConnection con = new SqlCeConnection(conStr);
            using(con)
            {
            SqlCommand cmd = new SqlCeCommand("SELECT OrderID FROM Order", con);
            string OrderID = cmd.ExecuteScalar().ToString();
            Console.WriteLine(OrderID);
            }

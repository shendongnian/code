    foreach (DataRow dr in dt.Rows)
    {
        string cardNumber = dr["cardNumber"].ToString();
        bool isValid = cardNumber.ToString().LuhnCheck();
        Console.WriteLine("{0} is {1}valid", cardNumber, isValid  ? "" : "not ");
        string isValidSqlBool = isValid ? "1" : "0";
        SqlCommand cmd = new SqlCommand("update MyTable SET LuhnSatisfied = " + isValidSqlBool + " where cardNumber =" + cardNumber, con);           
        cmd.ExecuteNonQuery();
    } 

    var sql = "insert into orderrecords_table values " +
              "(?orderId,                            " +
              " ?customercode,                       " +
              " ?customer,                           " +
              " ?telephone,                          " +
              " ?license,                            " +
              " ?driver,                             " +
              " ?address                             " +
              " ?locationType,                       " +
              " ?pickup,                             " +
              " ?customerType,                       " +
              " ?totalPrice,                         " +
              " ?status,                             " +
              " ?note,                               " +
              " ?sandreceiptNo,                      " +
              " ?createTiming,                       " +
              " ?currentTime)                        ";
    using (var myCommand4 = new MySqlCommand(sql, connection))
    {
       myCommand4.Parameters.AddWithValue("?orderId", OrderIDLabel.Text) ;
       myCommand4.Parameters.AddWithValue("?customercode", customerCode);
       myCommand4.Parameters.AddWithValue("?customer", customer);
       myCommand4.Parameters.AddWithValue("?telephone", TelComboBox.Text);
       myCommand4.Parameters.AddWithValue("?license", LicenseComboBox.Text);
       myCommand4.Parameters.AddWithValue("?driver", DriverComboBox.Text);
       myCommand4.Parameters.AddWithValue("?address", AddressComboBox.Text);
       myCommand4.Parameters.AddWithValue("?locationType", LocationTypeComboBox.Text);
       myCommand4.Parameters.AddWithValue("?pickup", PickupComboBox.Text);
       myCommand4.Parameters.AddWithValue("?customerType", CustomerTypeLabel.Text);
       myCommand4.Parameters.AddWithValue("?totalPrice", Convert.ToDecimal(TotalPriceLabel.Text));
       myCommand4.Parameters.AddWithValue("?status", status);
       myCommand4.Parameters.AddWithValue("?note", status);
       myCommand4.Parameters.AddWithValue("?sandreceiptNo", sandReceiptNo);
       myCommand4.Parameters.AddWithValue("?createTiming", createtiming);
       myCommand4.Parameters.AddWithValue("?currentTime", DateTime.Now);
	  
	   myCommand4.ExecuteNonQuery();
    }

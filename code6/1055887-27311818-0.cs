    private void btn_Submit_Click(object sender, EventArgs e)
    {
        if (isValidData())
        {
            //CONVERT FORM VALUES AND STORE IN VARIABLES TO SEND TO MYSQL QUERY
            DateTime saleTime = saleDatePicker.Value;
            Decimal price = Convert.ToDecimal(txt_Price.Text);
            string customerName = txt_CustomerName.Text;
            string customerPhone = txt_CustomerPhone.Text;
            string description = rTxt_Description.Text;
            string query = "INSERT into SALES VALUES (@stime, @price, @cname,@cphone,@cdesc)";
            List<MySqlParameter> prms = new List<MySqlParameter>()
            {
                new MySqlParameter {ParameterName="@stime", MySqlDbType=MySqlDbType.DateTime, Value =  saleTime },
                new MySqlParameter {ParameterName="@price", MySqlDbType=MySqlDbType.Decimal, Value =  price },
                new MySqlParameter {ParameterName="@cname", MySqlDbType=MySqlDbType.VarChar, Value =  customerName, Size = 150 },
                new MySqlParameter {ParameterName="@cphone", MySqlDbType=MySqlDbType.VarChar, Value = customerPhone , Size = 150 },
                new MySqlParameter {ParameterName="@desc", MySqlDbType=MySqlDbType.VarChar, Value = description , Size = 150 }
            };
            insertValues(query, prms);
        }
    }
    private void insertValues(string q, List<MySqlParameter> parameters)
    {
        using(MySqlConnection con = new MySqlConnection(....))
        using(MySqlCommand cmd = new MySqlCommand(q, con))
        {
            con.Open();
            con.Parameters.AddRange(parameters.ToArray());
            int rowsInserted = cmd.ExecuteNonQuery();
            return rowsInserted;
        }
    }

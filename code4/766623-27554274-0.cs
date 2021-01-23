        private void queryBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //Initialize sqlconnection
            SqlConnection myConnection;
            //Convert date in to proper int format to match db
            int fromDate = int.Parse(dateTimePickerStartDate.Value.ToString("yyyyMMdd"));
            int toDate = int.Parse(dateTimePickerEndDate.Value.ToString("yyyyMMdd"));
            //Setup Parameters
            SqlParameter paramFromDate;
            SqlParameter paramToDate;
            SqlParameter paramItemNo;
            SqlParameter paramCustomerNo;
            
            //Fill the data using criteria, and throw any errors
            try
            {
                myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                using (myConnection)
                {
                    using (SqlCommand myCommand = new SqlCommand())
                    {
                        //universal where clause stuff
                        string whereclause = "WHERE ";
                        //Add date portion
                        paramFromDate = new SqlParameter();
                        paramFromDate.ParameterName = "@FromDate";
                        paramFromDate.Value = fromDate;
                        paramToDate = new SqlParameter();
                        paramToDate.ParameterName = "@ToDate";
                        paramToDate.Value = toDate;
                        myCommand.Parameters.Add(paramFromDate);
                        myCommand.Parameters.Add(paramToDate);
                        whereclause += "(TableName.date BETWEEN @FromDate AND @ToDate)";
                        //Add item num portion
                        if (!string.IsNullOrEmpty(itemNo))
                        {
                            paramItemNo = new SqlParameter();
                            paramItemNo.ParameterName = "@ItemNo";
                            paramItemNo.Value = itemNo;
                            myCommand.Parameters.Add(paramItemNo);
                            whereclause += " AND (Tablename.item_no = @ItemNo)";
                        }
                        //Add customer number portion
                        if (!string.IsNullOrEmpty(customerNo))
                        {
                            paramCustomerNo = new SqlParameter();
                            paramCustomerNo.ParameterName = "@CustomerNo";
                            paramCustomerNo.Value = customerNo;
                            myCommand.Parameters.Add(paramCustomerNo);
                            whereclause = whereclause + " AND (Tablename.cus_no = @CustomerNo)";
                        }
                        string sqlquery = "SELECT * FROM TableName ";
                        sqlquery += whereclause;
                        //MessageBox.Show(sqlquery);
                        myCommand.CommandText = sqlquery;
                        myCommand.CommandType = CommandType.Text;
                        myCommand.Connection = myConnection;
                        this.exampleTableAdapter.ClearBeforeFill = true;
                        this.exampleTableAdapter.Adapter.SelectCommand = myCommand;
                        this.exampleTableAdapter.Adapter.Fill(this.ExampleDataSet.ExampleTable);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

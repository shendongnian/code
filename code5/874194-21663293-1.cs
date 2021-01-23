    private int AddPaymentRecord()
    {
        int result = 0;
        // The command text contains two statements separated by a semicolon
        String strCommandText = @"INSERT PAYMENT(amount, amountPaid, paymentDate, 
                                  paymentType, appointmentID) VALUES (@Newamount,
                                  @NewamountPaid,@NewpaymentDate,@NewpaymentType, 
                                  @NewappointmentID); 
                                 UPDATE Appointment SET aStatus=@cbaStatus
                                 WHERE appointmentID = @NewappointmentID";
        string strConnectionString = ConfigurationManager.ConnectionStrings["sacpConnection"].ConnectionString;
        using(SqlConnection myConnect = new SqlConnection(strConnectionString))
        {
             myConnect.Open();
             // Start a transaction to be sure that the two commands are both executed
             SqlTransaction tran = myConnect.BeginTransaction();
             try
             {
               using(SqlCommand updateCmd = new SqlCommand(strCommandText, myConnect, tran))
               {
                  updateCmd.Parameters.AddWithValue("@Newamount", txtamount.Text);
                  updateCmd.Parameters.AddWithValue("@NewamountPaid", txtamountPaid.Text);
                  updateCmd.Parameters.AddWithValue("@NewpaymentDate", dtppaymentDate.Value);
                  if (rbCash.Checked)
                    updateCmd.Parameters.AddWithValue("@NewpaymentType", "Cash");
                  else
                    updateCmd.Parameters.AddWithValue("@NewpaymentType", "Credit Card");
                  updateCmd.Parameters.AddWithValue("@NewappointmentID", txtappointmentID.Text);
                  string value = cbaStatus.SelectedItem == null ? 
                           "waiting" : cbaStatus.SelectedItem.ToString();
                  // Add also the parameter required by the second batch statement
                  updateCmd.Parameters.AddWithValue("@cbaStatus", value);
                  result = updateCmd.ExecuteNonQuery();
                  // If we reach this point we have updated both records. 
                  // Commit the changes 
                  tran.Commit();
               }
               return result;
             }
             catch
             {
                // Something wrong. rollback any changes and rethrow the exception
                // let the caller code handle this exception.
                tran.Rollback();
                throw;
             }
         }
    }

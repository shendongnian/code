    private void DeleteAfromAllB(Object a)
    {
        try
        {
            using (var con = new SqlConnection())
            {
                con.open();
                using (var cmd = new SqlCommand("STP_B_Delete_Referenc_To_A", con))
                {
                    // some parameters
                    // some sort of Execute
                    // e.g.: cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                //ExceptionHandling
            }
        }
    }
    public void DeleteAfromAllB_TopLevel(Object a)
    {
        using (var scope = new TransactionScope())
        {
            DeleteAfromAllB(a);
            // The Complete method commits the transaction. If an exception has been thrown, 
            // Complete is not  called and the transaction is rolled back.
            scope.Complete();
        }
    }

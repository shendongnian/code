            try
            {
                numberofRecords = (Int32)objCommand.ExecuteScalar();
                return numberofRecords;
            }
            catch (Exception ex)
            {
                //here you can enter into debug mode and see the exception "ex"
                return -1;
            }
            finally
            {
                myConn.Close();
            }

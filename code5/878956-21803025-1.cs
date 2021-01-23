    private void TestConn_btn_Click(object sender, EventArgs e)
    {
    	this.Cursor = Cursors.WaitCursor;
        DbConnection DBConnTest;
        if (DataSrc_cbx.SelectedIndex == 1)
        {
            DBConnTest = new SqlConnection("Server="+DatabaseAddress_Value+"; Database="+DatabaseName_Value+";Trusted_Connection=true");
            try
            {
                DBConnTest.Open();
                MessageBox.Show("\nTEST SUCCESSFUL\n");
            }
            catch (Exception exception)
            {
                MessageBox.Show("TEST FAILED Exception Thrown: " + exception.Message);
            }
            finally
            {
                DBConnTest.Close();
            }
        }
        this.Cursor = Cursors.Default;
      }

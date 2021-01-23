    int count = 0;
    private void btnCancelSearch_Click(object sender, EventArgs e)
    {
    if(count <3){
        count++;
        
        try
        {
            //Connect to Database
            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            //Define SQL Query (Select)
            strSQL = "SELECT * FROM Bookings WHERE BookingNo = '" + txtCnlBookingNo.Text + "'";
            cmd.CommandText = strSQL;
            OracleDataReader dr = cmd.ExecuteReader();
            dr.Read();
            txtBookingNo.Text = dr.GetValue(0).ToString();
            txtBkgSurname.Text = dr.GetValue(1).ToString();
            txtBkgForename.Text = dr.GetValue(2).ToString();
            txtBkgContactNo.Text = dr.GetValue(3).ToString();
            txtBkgStreet.Text = dr.GetValue(4).ToString();
            txtBkgTown.Text = dr.GetValue(5).ToString();
            txtBkgCounty.Text = dr.GetValue(6).ToString();
            txtBkgCountry.Text = dr.GetValue(7).ToString();
            txtBkgEmail.Text = dr.GetValue(8).ToString();
            cboBkgNoGuests.Text = dr.GetValue(9).ToString();
            cboBkgPayment.Text = dr.GetValue(10).ToString();
            dtpBkgCheckIn.Text = dr.GetValue(11).ToString();
            dtpBkgCheckOut.Text = dr.GetValue(12).ToString();
        }
        catch
        {
            //Display confirmation message
            MessageBox.Show("Not a valid Booking No");
        }
    }else
    {
        //Implement whatever search you want here
        //And disable your button here
    }
    }

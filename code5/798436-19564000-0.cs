    int _orderID = Convert.ToInt32(orderID.Text);
    string _trackingID = trackingNumber.Text;
    SqlConnection myConnection = new SqlConnection("Data Source=MYDATABASESERVER;Initial Catalog=DATABASENAME;User ID=USERNAME;Password=PASSWORD");
    SqlCommand myCommand = new SqlCommand("UPDATE Shipment SET TrackingNumber = @tracking WHERE OrderId = @order", myConnection);
    try
    {
        myConnection.Open();
        myCommand.Parameters.AddWithValue("@order", _orderID);
        myCommand.Parameters.AddWithValue("@tracking", _trackingID);
        int rowsUpdated = myCommand.ExecuteNonQuery();
        myConnection.Close();
        if(rowsUpdated > 0)
        {
            SuccessLabel.Text = "Thank you, tracking details have been updated";
            SuccessLabel.Visible = true;
        }
        orderID.Text = "";
        trackingNumber.Text = "";
    }
    catch (Exception f)
    {
        errorLabel.Text =  f.Message.ToString();
        errorLabel.Visible = true;
        return;
    }

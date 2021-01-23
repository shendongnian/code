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

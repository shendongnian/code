    object result = myCommand.ExecuteScalar();
    if (result == DBNull.Value)
    {
        friendRequestSent.Visible = false;
        addFriend.Visible = true;
    }
    else if (Convert.ToString(result) == "0")
    {
        friendRequestSent.Visible = true;
        addFriend.Visible = false;
    }

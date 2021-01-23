    public void UpdateCustomer(string strUserId, string strFName, string strFValue)
    {
        ...
        com.Parameters.Add("@ClientNo", ).Value = strUserId;
        com.Parameters.Add("@newValue", ).Value = strFValue;

     public string BindCreatedGrid(string status)
    {
        Login l = new Login();
        long userId = l.UserId;
        if (userId != 0)
        {
            TransferRequestMethods trm = new TransferRequestMethods();
            status = GetStatus(status);
            DataSet dsResult = trm.GetCreatedHardwareTransferRequestList(status, userId);
            string s =dsResult.GetXml();
            return s;
        }
        else
        {
            return "Expired";
        }
    }

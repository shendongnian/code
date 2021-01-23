    public void AllocatePosition(List<DbConnect.BidList> createBidList)
    {
        for (int i = 0; i < createBidList.Count; i++)
        {
            MessageBox.Show("Position: " + i + " Item: " + createBidList[i].ToString());
        }
    }

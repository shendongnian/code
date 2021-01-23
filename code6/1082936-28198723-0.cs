    public void AllocatePosition(List<DbConnect.BidList> createBidList)
    {
        for (int i = 0; i < createBidList.Count; i++)
        {
            MessageBox.Show("Position: " + i + " Item: " + createBidList[i].ToString()); // show position of item (i.e. is it first, second, third...on the list
        }
    }

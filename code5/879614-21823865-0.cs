    public resultType GetData(int ClientID, DateTime CreatedDate)
    {
        var Row = DB.tblPlans
                    .Where(m => m.fkClient_Id == ClientID && m.PlanDate.Date <= CreatedDate)
                    .OrderByDescending(m => m.Id)
                    .FirstOrDefault();
    }

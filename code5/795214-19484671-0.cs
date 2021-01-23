    public String[] ReturnPatientIDs(int CounsellingRoomID)
    {
        var query = this.context.CounsellingMessages
                        .Where(c => c.CounsellingRoomID == CounsellingRoomID)
                        .Select(c => c.Chatname)
                        .Distinct();
        return query.ToArray();
    }

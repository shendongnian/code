    public static int GetMemberActivity(List<IMember> memberList)
    {
        var groupedList = memberList.GroupBy(x => x.MemberID);
         
        return groupedList.Count();  // I'm just guessing what you want to return here
    }

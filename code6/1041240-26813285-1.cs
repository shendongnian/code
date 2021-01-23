    public static int GetMemberActivity(List<IMember> memberList)
    {
        var groupedList = memberList.GroupBy(x => x.SampleProperty);
         
        return groupedList.Count();
    }

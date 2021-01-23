     private string SelectedMembersDetailsGet(List<string> membersIdList, List<Missions> missionsList)
     {
        string selectedMembersName = string.Empty;
        IEnumerable<Missions> commonMissionsList = null;
        membersIdList.Add("XYZ");
        commonMissionsList = MissionsGet();  //Returns 4 records
        if (commonMissionsList != null)
        {
            foreach(var mission in commonMissionsList)
            {
                   missionsList.Add(mission);
            }
        }
        return selectedMembersName;
    }

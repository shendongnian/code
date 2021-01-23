    List<Meeting> meetings = 
        (from m in crdb.tl_cr_Meetings
        join p in crdb.tl_cr_Participants on m.MeetingID equals p.MeetingID
        where p.TimeOut == null
        group m by new { m.MeetingID, m.MeetingName, m.HostUsername, MeetingID2 = m.tl_cr_BlueJeansAccount.MeetingID, m.StartTime } into m
        select new Meeting
        {
          MeetingID = m.Key.MeetingID,
          MeetingName = m.Key.MeetingName,
          HostUserName = m.Key.HostUsername,
          BlueJeansMeetingID = m.Key.MeetingID2,
          StartTime = m.Key.StartTime,
          Participants = (from pa in crdb.tl_cr_Participants
                           where pa.MeetingID == m.Key.MeetingID
                           select pa.tl_cr_BlueJeansAccount.DisplayName).ToList()
        }).ToList();

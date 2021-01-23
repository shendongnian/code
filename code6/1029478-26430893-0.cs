     var meetings = crdb.tl_cr_Meetings.GroupJoin(crdb.tl_cr_Participants,
                                                    k => k.MeetingID,
                                                    k => k.MeetingID,
                                                    (o,i) => new
                                                    {
													   MeetingID = o.MeetingID,
													   MeetingName = o.MeetingName,
													   HostUserName = o.HostUsername,
													   BlueJeansMeetingID = o.tl_cr_BlueJeansAccount.MeetingID,
													   StartTime = o.StartTime,
													   Participants = i.Select(s => s.DisplayName)
                                                    }).ToList();

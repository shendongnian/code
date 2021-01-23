    var memberData = (from u in _objGroupRepositoty.Value.GetUsers()
                                             join umedia in _objGroupRepositoty.Value.GetMediaDetails() on u.userid equals umedia.userid
                                             join gm in _objGroupRepositoty.Value.GetGroupMaster() on groupId equals gm.GDID
                                             join m in _objGroupRepositoty.Value.GetGroupMembers() on u.userid equals m.userid
                                             join media in _objGroupRepositoty.Value.GetMediaDetails() on gm.GDID equals media.GDID
                                       
                                             where (m.GDID == groupId
                                             && m.IsActive == true
                                             && gm.IsActive == true
                                             && u.IsActive == true)
                                             select new
                                             {
                                                 userid = u.userid,
                                                 firstname = u.firstname,
                                                 lastname = u.lastname,
                                                 mobile_no = u.mobile_no,
                                                 imagepath = umedia.media_path,
                                                 IsAdmin = m.IsAdmin,
                                                 GroupID = gm.GroupID,
                                                 group_name = gm.group_name,
                                                 tagline = gm.tagline,
                                                 groupImage = media.media_path,
                                                 ChatRoomId = gm.ChatRoomId,
                                                 OperationType
                                                  
                                                 //newMember = newMemberLists.Contains(u.userid) than "Y" : "N",
                                             }).ToList().Distinct();

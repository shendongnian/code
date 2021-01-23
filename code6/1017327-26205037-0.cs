    getFirstChatMessage() 
        {
            var entities = new FreeEntities();
            //User ID
            Business.User user = Business.User.getUserBySecurityToken();
            
            // Create new list of Chat
            List<Chat> chatList = new List<Chat>();
    
              var res = from c in entities.tbl_ChatLog
              where c.UserID == user.uid
              group c by c.UserID
              into groups
              select groups.OrderByDescending(p => p.DateAdded).FirstOrDefault();
    
            foreach (var r in res) 
            {
              chatList.Add(new Chat() 
              {
               uid = (int)r.UserID, 
               sendToUserID = (int)r.SendToUserID,
               message = (from m in entities.tbl_ChatLog where m.UserID == (int)r.SendToUserID 
               orderby r.DateAdded descending select m.Message).FirstOrDefault(),
               dateAdded = (DateTime)r.DateAdded, 
               fullName = (from b in entities.tbl_Bio where b.UserID == (int)r.SendToUserID 
               select b.FirstName + " " +      b.SurName).FirstOrDefault() 
              });
            }
            return chatList;
        }

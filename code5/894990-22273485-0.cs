    //Elsewhere in your code
    class Result
    {
        public usercontact UserContact {get; set;}
        public EmailRecipientinGroup Group {get; set;}
        public Zeekuser ZeekUser {get; set;}
    }
    
    
    
    var query = (from s in dc.UserContacts
                 join g in dc.EmailRecipientInGroups on s.UserEmailRecipient.RID equals g.RID
                 join zk in dc.ZeekUsers on s.UserID equals zk.UserId
                 where s.aspnet_User.LoweredUserName.Equals(strUserName.ToLower())
                 && !g.UserEmailRecipientGroup.IsDeleted
                 && !s.UserEmailRecipient.IsDeleted
                 select new Result{ UserContact = s, Group  = g, ZeekUser = zk }); //Only this line changed.

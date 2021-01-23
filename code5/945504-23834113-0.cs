            List<user> listUsers = new List<user>();
        public int groupUsersbyID(int _groupID)
        {
           var ListOfUsers = (from g in listUsers where g.groupID == _groupID select g).ToList();
           var count = ListOfUsers.Count();
           var totalCreditforGroup = 0;
           var GroupCredit = 0;
           foreach (var indidCredit in ListOfUsers)
            {
                totalCreditforGroup = totalCreditforGroup + indidCredit.individualCredit;
                GroupCredit = totalCreditforGroup / count;
            }
           return GroupCredit;
        }
        public int returnGroupID(int userId)
        {
            var GroupIDforUser = (from i in listUsers where i.userID == userId select i.groupID).FirstOrDefault();
            return GroupIDforUser;
        }
    
        public class user
        {
            public int userID { get; set; }
            public int groupID { get; set; }
            public int individualCredit { get; set; }
            public int groupCredit { get; set; }
        }
